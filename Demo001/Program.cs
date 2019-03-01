//============================================================================
// John Dugger
// 02/27/2019
// ---------------------------------------------------------------------------
// My first foray into Dependency Injection, sort of. The idea was to use 
// the DbContext in EF6 to allow the app to talk to any database supported 
// by the Entity Framework, mostly Sql Server and Oracle. 
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// No actual dependency injection, yet. This mostly shows how to manage 
// database connections and some EF Code First techniques
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// I also wanted to experminent with using EF Code First as a tool to 
// initialize my databases, create the prototype tables, insert some test 
// data etc. It works reaonsably well with Sql Server, not so much with 
// Oracle. I still have to 'adjust' the tables in both Oracle and Sql Server
// but the data load parts seem to work ok.
//============================================================================

using System;
using DependencyInjectionDemo.DataConnections;
using WebApp2.Models.Addresses;

namespace DependencyInjectionDemo
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("========= Countries ========");
            ShowCountriesAll();

            ShowStatesAll();

            Console.WriteLine("----------------------------");
            Console.WriteLine("Press the ANY key to exit:");
            Console.ReadLine();
        }


        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public static void ShowStatesAll()
        {
            using (var conn = SqlExpDBConnection.SqlConnection())
            {
                conn.Open();
                CountryCodesDB cntry_db1 = new CountryCodesDB(conn);
                foreach (CountryCode cnty_code in cntry_db1.CountryCodesList)
                {
                    StateCodesDB state_db1 = new StateCodesDB(conn, cnty_code);
                    ShowStates(state_db1, cnty_code.CountryName);
                }
            }
        }
        public static void ShowStates(StateCodesDB db_states , string cntry_name)
        {
            Console.WriteLine("========= States for {0} ========", cntry_name);
            foreach (StateCode cc in db_states.StateCodesList)
            { Console.WriteLine("Country = {0} ", cc.StateName); }
        }


        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public static void ShowCountriesAll()
        {
            Console.WriteLine("--------- Oracle ---------");
            ShowCountries(new CountryCodesDB(OracleDBConnection.SqlConnection()));
            Console.WriteLine("--------- Sql Express ---------");
            ShowCountries(new CountryCodesDB(SqlExpDBConnection.SqlConnection()));
            Console.WriteLine("--------- Sql Remote ---------");
            ShowCountries(new CountryCodesDB(SqlRmtDBConnection.SqlConnection()));
        }
        public static void ShowCountries(CountryCodesDB db_countries)
        {
            foreach (CountryCode cc in db_countries.CountryCodesList)
            { Console.WriteLine("Country = {0} ", cc.CountryName); }
        }

    }
}
