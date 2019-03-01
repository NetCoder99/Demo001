//============================================================================
// John Dugger
// 02/27/2019
// Here is my initial attempt at encapulation with Entity Framework 6.
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// NOTE: The list returned by this is static, the idea is instantiate this 
// one time only and then any process that needs it can access the public 
// lists property, without a round trip to the database.
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// NOTE: I also added some code that uses the EF6 Code First to create and 
// populate the data base tables.
//============================================================================

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;

namespace WebApp2.Models.Addresses
{
    class StateCodesDB : DbContext
    {
        public StateCodesDB(DbConnection sql_con, CountryCode cntry_code) : base(sql_con, false) { this.Initialize(cntry_code); }

        // the dbcontext does not survive the init process but for this I don't care, use a List<>
        // to cache the data and make a read only public property available to anyone that needs the 
        // data we extracted from the database.
        private List<StateCode> _StateCodesList = new List<StateCode>();
        public List<StateCode> StateCodesList { get { return _StateCodesList; } }

        // Bind EF to the poco
        public DbSet<StateCode> StateCodes { get; set; }

        // the idea is that this will work against any db connection, if there is no data then 
        // create some, save to the database and then return whatever list this supports 
        private void Initialize(CountryCode cntry_code)
        {
            if (_StateCodesList.Count == 0)
            {
                using (var ctx = this)
                {
                    // using EF6, create the table and save the list on the first ever call 
                    var query = from c_codes in ctx.StateCodes
                                where c_codes.CountryCodeId == cntry_code.CountryCodeId
                                select c_codes;
                    if (query.Count() == 0)
                    {
                        // !!!! di for this, version 2 !!!!
                        switch (cntry_code.CountryAbbr)
                        {
                            case "MEX" :
                                ctx.StateCodes.AddRange(GetStateCodesMEX.GetStates());
                                break;
                            case "CAN":
                                ctx.StateCodes.AddRange(GetStateCodesCAN.GetStates());
                                break;
                            case "USA":
                                ctx.StateCodes.AddRange(GetStateCodesUSA.GetStates());
                                break;
                            default: // di would make this condition impossible ?
                                throw new Exception("Unkown Country Code");
                        }

                        ctx.SaveChanges();
                    }
                    // else use data from database
                    this._StateCodesList = query.ToList();
                }
            }
        }


    }
}
