//============================================================================
// John Dugger
// 02/27/2019
// Normally I define connection strings in code, I can control encryption, 
// and other stuff, for this demo all of that is defined in the app.config
// but I kept the concept around using these. Later versions will have more
// stuff...
//============================================================================
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;

namespace DependencyInjectionDemo.DataConnections
{
    class SqlExpDBConnection : DbContext
    {
        public static SqlConnection SqlConnection()
        {
            var c1 = ConfigurationManager.ConnectionStrings["WebApp2Exp"];
            return new SqlConnection(c1.ConnectionString);
        }
    }
}
