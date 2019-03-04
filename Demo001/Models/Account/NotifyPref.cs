//============================================================================
// John Dugger
// 02/27/2019
// Not active at thsi point, this will be the EF Code First activity that 
// supports the database objects in my Web Application demo project.
//============================================================================
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApp2.Models.Account
{
    public class NotifyPref 
    {
        public int    NotifyPrefId      { get; set; }
        public string NotifyPrefName    { get; set; }
        public bool   NotifyPrefChecked { get; set; }
        public NotifyPref()
        {
            using (var ctx = new AccountDb())
            {
                var query = from st in ctx.NotifyPref select st;
                if (query.Count() == 0)
                {
                    List<NotifyPref> n_prefs = new List<NotifyPref>();
                    n_prefs.Add(new NotifyPref("Email"));
                    n_prefs.Add(new NotifyPref("SMS"));
                    n_prefs.Add(new NotifyPref("Text"));
                    ctx.SaveChanges();
                }
            }
        }

        public NotifyPref(string npref_str)
        { this.NotifyPrefName = npref_str; }

    }
}