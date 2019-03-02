//============================================================================
// John Dugger
// 02/27/2019
// Hard coded list that the DbContext object can access to initialize 
// the database tables.
//============================================================================
using System.Collections.Generic;

namespace WebApp2.Models.Addresses
{
    public class GetStateCodesCAN : IGetStates
    {
        public int CountryCode { get { return 3; } }
        public List<StateCode> GetStates()
        {
            List<StateCode> rtn_list = new List<StateCode>();
            rtn_list.Add(new StateCode(3, "AB", "Alberta"));
            rtn_list.Add(new StateCode(3, "BC", "British Columbia"));
            rtn_list.Add(new StateCode(3, "MB", "Manitoba"));
            rtn_list.Add(new StateCode(3, " NB", "New Brunswick"));
            rtn_list.Add(new StateCode(3, "NL", "Newfoundland and Labrador"));
            rtn_list.Add(new StateCode(3, "NT", "Northwest Territories"));
            rtn_list.Add(new StateCode(3, "NS", "Nova Scotia"));
            rtn_list.Add(new StateCode(3, "NU", "Nunavut"));
            rtn_list.Add(new StateCode(3, "ON", "Ontario"));
            rtn_list.Add(new StateCode(3, "PE", "Prince Edward Island"));
            rtn_list.Add(new StateCode(3, "QC", "Quebec"));
            rtn_list.Add(new StateCode(3, "SK", "vSaskatchewan"));
            rtn_list.Add(new StateCode(3, "YT", "Yukon"));
            return rtn_list;
        }
    }
}