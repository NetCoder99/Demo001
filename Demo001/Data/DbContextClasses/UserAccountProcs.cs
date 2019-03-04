using Demo001.DataConnections;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo001.Data.DbContextClasses
{
    class UserAccountProcs
    {
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public static void InitialiazeDB()
        {
            DbConnection db_con = SqlExpDBConnection.SqlConnection();


        }
    }
}
