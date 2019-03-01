﻿//============================================================================
// John Dugger
// 02/27/2019
// I am using Entity Framework 6, so need to define the EF stuff. 
// Also, the list of countries is static and immutable, extract once and 
// make available to all callers.
//============================================================================
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Data.Common;

namespace WebApp2.Models.Addresses
{

    class CountryCodesDB : DbContext
    {

        public CountryCodesDB(DbConnection sql_con)    : base(sql_con, false)  { this.Initialize(); }

        // the dbcontext does not survive the init process but for this I don't care, use a List<>
        // to cache the data and make a read only public property available to anyone that needs the 
        // data we extracted from the database.
        private List<CountryCode> _CountryCodesList = new List<CountryCode>();
        public  List<CountryCode> CountryCodesList { get { return _CountryCodesList; } }

        // Bind EF to the poco
        public DbSet<CountryCode> CountryCodes { get; set; }

        // the idea is that this will work against any db connection, if there is no data then 
        // create some, save to the database and then return the country codes 
        private void Initialize()
        {
            if (_CountryCodesList.Count == 0)
            {
                using (var ctx = this)
                {
                    // using EF6, create the table and save the list on the first ever call 
                    var query = from c_codes in ctx.CountryCodes select c_codes;
                    if (query.Count() == 0)
                    {
                        CountryCode c1 = new CountryCode(1, "USA", "United States");
                        CountryCode c2 = new CountryCode(2, "MEX", "Mexico");
                        CountryCode c3 = new CountryCode(3, "CAN", "Canada");
                        ctx.CountryCodes.Add(c1);
                        ctx.CountryCodes.Add(c2);
                        ctx.CountryCodes.Add(c3);
                        ctx.SaveChanges();
                    }
                    // else use data from database
                    _CountryCodesList = query.ToList();
                }
            }
        }


    }
}