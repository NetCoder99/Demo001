//============================================================================
// John Dugger
// 02/27/2019
// Here is my initial encapulation with Entity Framework 6.
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// NOTE: The list returned by this is static, the idea is instantiate this 
// one time only and then any process that needs it can access the public 
// lists property, without a round trip to the database.
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// NOTE: I also added some code that uses the EF6 Code First to create and 
// populate the data base tables.
//============================================================================
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Data.Common;
using System;

namespace WebApp2.Models.Addresses
{

    class CountryCodesDB : DbContext
    {
        private static List<CountryCode> _CountryCodesList = new List<CountryCode>();
        public static List<CountryCode> CountryCodesList { get { return _CountryCodesList; } }

        public CountryCodesDB(DbConnection sql_con)    : base(sql_con, true)  { }

        // Bind EF to the poco
        public DbSet<CountryCode> CountryCodes { get; set; }

        // Called only when I want to refresh the database 
        public void Initialize()
        {
            if (CountryCodes.Count() == 0)
            {
                CountryCode c1 = new CountryCode(1, "USA", "United States");
                CountryCode c2 = new CountryCode(2, "MEX", "Mexico");
                CountryCode c3 = new CountryCode(3, "CAN", "Canada");
                CountryCodes.Add(c1);
                CountryCodes.Add(c2);
                CountryCodes.Add(c3);
                SaveChanges();
            }
        }


    }
}
