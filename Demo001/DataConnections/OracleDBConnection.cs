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

