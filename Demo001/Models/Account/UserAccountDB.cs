using Demo001.Data.TestFiles;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp2.Models.Account;

namespace Demo001.Models.Account
{
    class UserAccountDB : DbContext
    {
        public UserAccountDB(DbConnection sql_con) : base(sql_con, true) { }
        public DbSet<UserDetail> UserDetails { get; set; }

        public void Initialize(IGetTestData getTestData, bool truncate = false)
        {
            if (truncate) { Database.ExecuteSqlCommand("TRUNCATE TABLE [WebApp2].[UserDetails]"); }

            List<UserDetail> dtls_list = getTestData.GetData();
            var query = from user_dtls in UserDetails select user_dtls;
            var t1 = query.ToList();
            if (query.Count() == 0)
            {
                UserDetails.AddRange(dtls_list);
                SaveChanges();
            }
        }

    }
}
