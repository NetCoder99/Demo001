//============================================================================
// John Dugger
// 02/27/2019
// I am using Entity Framework 6, so need to define the EF stuff. 
// Also, the list of states is static and immutable, extract once and 
// make available to all callers.
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

        private List<StateCode> _StateCodesList = new List<StateCode>();
        public List<StateCode> StateCodesList { get { return _StateCodesList; } }

        public DbSet<StateCode> StateCodes { get; set; }

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
