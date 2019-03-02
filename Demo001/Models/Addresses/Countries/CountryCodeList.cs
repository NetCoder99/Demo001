//============================================================================
// John Dugger
// 03/02/2019
// Several of the 'lists' that I use my apps are static, they rarely, if 
// ever, change and they will never be updated by the application. 
//============================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp2.Models.Addresses
{
    class CountryCodeList 
    {
        private static List<CountryCode> _CountryCodesList = new List<CountryCode>();

        public static void Initialize(CountryCodesDB country_db)
        { _CountryCodesList = country_db.CountryCodes.ToList(); }

        public static List<CountryCode> Get()
        { return _CountryCodesList; }

        public static CountryCode Get(string country_abbr)
        { return _CountryCodesList.Where(w => w.CountryAbbr == country_abbr).First(); }

    }
}
