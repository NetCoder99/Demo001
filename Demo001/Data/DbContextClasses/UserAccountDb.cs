using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp2.Models.Account
{
    class UserAccountDb : DbContext
    {
        public UserAccountDb() : base("WebApp2")
        { }

        public DbSet<UserAccount> UserAccount { get; set; }
    }
}
