using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;

namespace DependencyInjectionDemo.DataConnections
{
    class SqlRmtDBConnection : DbContext
    {
        public static SqlConnection SqlConnection()
        {
            var c1 = ConfigurationManager.ConnectionStrings["WebApp2Rmt"];
            return new SqlConnection(c1.ConnectionString);
        }

    }
}
