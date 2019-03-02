//============================================================================
// John Dugger
// 02/27/2019
// Connect to the database and get the requested list. I also added some 
// code that uses the EF6 Code First to create and populate the data base 
// tables, those are only called during development, when needed.
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
        public DbSet<StateCode> StateCodes { get; set; }
        public void Initialize()
        {
            Initialize(new GetStateCodesUSA());
            Initialize(new GetStateCodesUSA());
            Initialize(new GetStateCodesUSA());
        }

        private void Initialize(IGetStates states_list)
        {
            var query = from c_codes in StateCodes
                        where c_codes.CountryCodeId == states_list.CountryCode
                        select c_codes;
            if (query.Count() == 0)
            {
                StateCodes.AddRange(states_list.GetStates());
                SaveChanges();
            }
        }


    }
}
