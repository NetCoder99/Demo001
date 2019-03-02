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
        public StateCodesDB(DbConnection sql_con) : base(sql_con, true) { }
        public StateCodesDB(DbConnection sql_con, CountryCode cntry_code) : base(sql_con, true) { }
        public DbSet<StateCode> StateCodes { get; set; }
        private void Initialize()
        {
            StateCodes.AddRange(GetStateCodesMEX.GetStates());
            StateCodes.AddRange(GetStateCodesCAN.GetStates());
            StateCodes.AddRange(GetStateCodesUSA.GetStates());
            SaveChanges();
        }
        private void Initialize(CountryCode cntry_code)
        {
            var query = from c_codes in StateCodes
                        where c_codes.CountryCodeId == cntry_code.CountryCodeId
                        select c_codes;
            if (query.Count() == 0)
            {
                switch (cntry_code.CountryAbbr)
                {
                    case "MEX" :
                        StateCodes.AddRange(GetStateCodesMEX.GetStates());
                        break;
                    case "CAN":
                        StateCodes.AddRange(GetStateCodesCAN.GetStates());
                        break;
                    case "USA":
                        StateCodes.AddRange(GetStateCodesUSA.GetStates());
                        break;
                    default: // di would make this condition impossible ?
                        throw new Exception("Unkown Country Code");
                }

                SaveChanges();
            }
        }

    }
}
