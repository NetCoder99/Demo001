//============================================================================
// John Dugger
// 02/27/2019
// Here is my initial encapulation with Entity Framework 6.
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// NOTE: This will not be static, the checked state will change depending 
// on user input. For Code First DB init this will work not sure how this 
// will get wired up in the web page.
//============================================================================
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp2.Models.Addresses
{
    class NotifyPrefDB : DbContext
    {
        public NotifyPrefDB(DbConnection sql_con) : base(sql_con, true) {  }
        public DbSet<NotifyPref> NotifyPrefs { get; set; }
        public void Initialize()
        {
            if (NotifyPrefs.Count() == 0)
            {
                NotifyPrefs.Add(new NotifyPref("None"));
                NotifyPrefs.Add(new NotifyPref("Email"));
                NotifyPrefs.Add(new NotifyPref("SMS"));
                NotifyPrefs.Add(new NotifyPref("Text"));
                SaveChanges();
            }
        }
        public List<NotifyPref> Get()
        {
            return this.NotifyPrefs.ToList();
        }

    }
}
