//============================================================================
// John Dugger
// 02/27/2019
// Not active at this point.
//============================================================================
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp2.Models.Addresses;

namespace WebApp2.Models.Account
{
    public class AccountDb : DbContext
    {
        public AccountDb() : base("WebApp2")
        {   }

        public DbSet<LoginCreds>  LoginCreds  { get; set; }
        public DbSet<UserAccount> UserAccount { get; set; }
        public DbSet<NotifyPref>  NotifyPref  { get; set; }

    }
}