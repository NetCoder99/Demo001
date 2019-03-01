//============================================================================
// John Dugger
// 02/27/2019
// Normally I define connection strings in code, I can control encryption, 
// and other stuff, for this demo all of that is defined in the app.config
// but I kept the concept around using these. Later versions will have more
// stuff...
//============================================================================
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.Data.Entity;

namespace DependencyInjectionDemo.DataConnections
{
    class OracleDBConnection
    {
        public static OracleConnection SqlConnection()
        {
            var c1 = ConfigurationManager.ConnectionStrings["ORCL1DB"];
            OracleConnection ora_con = new OracleConnection(c1.ConnectionString);
            return ora_con;
        }

    }
}

