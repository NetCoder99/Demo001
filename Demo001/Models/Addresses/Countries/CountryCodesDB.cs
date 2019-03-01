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

namespace WebApp2.Models.Addresses
{

    class CountryCodesDB : DbContext
    {

        public CountryCodesDB(DbConnection sql_con)    : base(sql_con, true)  { }

        // the dbcontext does not survive the init process but for this I don't care, use a List<>
        // to cache the data and make a read only public property available to anyone that needs the 
        // data we extracted from the database.
        private List<CountryCode> _CountryCodesList = new List<CountryCode>();
        public  List<CountryCode> CountryCodesList { get { return _CountryCodesList; } }

        // Bind EF to the poco
        public DbSet<CountryCode> CountryCodes { get; set; }

        // the idea is that this will work against any db connection, if there is no data then 
        // create some, save to the database
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

        public List<CountryCode> Get()
        {
            return this.CountryCodes.ToList();
        }
        public CountryCode Get(string country_abbr)
        {
            return this.CountryCodes.Where(w=>w.CountryAbbr == country_abbr).First();
        }

        public void Add(CountryCode country_code)
        {
            CountryCodes.Add(country_code);
            SaveChanges();
        }

        public void Del(string country_abbr)
        {
            CountryCode c1 = Get(country_abbr);
            CountryCodes.Remove(c1);
            SaveChanges();
        }

    }
}
