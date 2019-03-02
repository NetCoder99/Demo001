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
// I also wanted to experiment with using EF Code First as a tool to 
// initialize my databases, create the prototype tables, insert some test 
// data etc. It works reaonsably well with Sql Server, not so much with 
// Oracle. I still have to 'adjust' the tables in both Oracle and Sql Server
// but the data load parts seem to work ok.
//============================================================================
using System;
using System.Data.Common;
using System.Collections.Generic;
using DependencyInjectionDemo.DataConnections;
using WebApp2.Models.Addresses;
using System.Data.Entity;

namespace DependencyInjectionDemo
{
    class Program
    {

        static void Main(string[] args)
        {
            InitialiazeDB();
            //InitialiazeLists();
            //ShowCountries();
            //ShowStates();

            Console.WriteLine("----------------------------");
            Console.WriteLine("Press the ANY key to exit:");
            Console.ReadLine();
        }



        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public static void InitialiazeDB()
        {
            DbConnection db_con = SqlExpDBConnection.SqlConnection();
            new CountryCodesDB(db_con).Initialize();
            new StateCodesDB(db_con).Initialize();
        }


        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public static void InitialiazeLists()
        {
            DbConnection db_con = SqlExpDBConnection.SqlConnection();
            CountryCodeList.Initialize(new CountryCodesDB(db_con));
            StateCodeList.Initialize(new StateCodesDB(db_con));
        }

        public static void ShowCountries()
        {
            Console.WriteLine("========= Countries ========");
            foreach (CountryCode cc in CountryCodeList.Get())
            { Console.WriteLine("Country = {0} ", cc.CountryName); }
        }

        public static void ShowStates()
        {
            foreach (CountryCode country_code in CountryCodeList.Get())
            {
                Console.WriteLine("========= States for {0} ========", country_code.CountryName);
                foreach (StateCode stateCode in StateCodeList.Get(country_code))
                { Console.WriteLine("State Abbr = {0}; State Name {1} ", stateCode.StateAbbr, stateCode.StateName); }
            }
        }



    }
}
