//============================================================================
// John Dugger
// 02/27/2019
// Connect to the database and get the requested list. I also added some 
// code that uses the EF6 Code First to create and populate the data base 
// tables, those are only called during development, when needed.
//============================================================================
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Data.Common;
using System;

namespace WebApp2.Models.Addresses
{

    public interface IWebApp2DBContext
    {
        void Initialize();
    }

    class CountryCodesDB : DbContext, IWebApp2DBContext
    {
        public CountryCodesDB(DbConnection sql_con)    : base(sql_con, true)  { }
        public DbSet<CountryCode> CountryCodes { get; set; }
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
