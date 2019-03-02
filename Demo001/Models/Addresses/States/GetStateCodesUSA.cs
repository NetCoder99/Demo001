//============================================================================
// John Dugger
// 02/27/2019
// Hard coded list that the DbContext object can access to initialize 
// the database tables.
//============================================================================
using System.Collections.Generic;

namespace WebApp2.Models.Addresses
{
    public class GetStateCodesUSA : IGetStates
    {
        public int CountryCode { get { return 1; } }

        public List<StateCode> GetStates()
        {
            List<StateCode> rtn_list = new List<StateCode>();
            rtn_list.Add(new StateCode(1, "AL", "ALABAMA"));
            rtn_list.Add(new StateCode(1, "AK", "ALASKA"));
            rtn_list.Add(new StateCode(1, "AZ", "ARIZONA"));
            rtn_list.Add(new StateCode(1, "AR", "ARKANSAS"));
            rtn_list.Add(new StateCode(1, "CA", "CALIFORNIA"));
            rtn_list.Add(new StateCode(1, "CO", "COLORADO"));
            rtn_list.Add(new StateCode(1, "CT", "CONNECTICUT"));
            rtn_list.Add(new StateCode(1, "DE", "DELAWARE"));
            rtn_list.Add(new StateCode(1, "FL", "FLORIDA"));
            rtn_list.Add(new StateCode(1, "GA", "GEORGIA"));
            rtn_list.Add(new StateCode(1, "HI", "HAWAII"));
            rtn_list.Add(new StateCode(1, "ID", "IDAHO"));
            rtn_list.Add(new StateCode(1, "IL", "ILLINOIS"));
            rtn_list.Add(new StateCode(1, "IN", "INDIANA"));
            rtn_list.Add(new StateCode(1, "IA", "IOWA"));
            rtn_list.Add(new StateCode(1, "KS", "KANSAS"));
            rtn_list.Add(new StateCode(1, "KY", "KENTUCKY"));
            rtn_list.Add(new StateCode(1, "LA", "LOUISIANA"));
            rtn_list.Add(new StateCode(1, "ME", "MAINE"));
            rtn_list.Add(new StateCode(1, "MD", "MARYLAND"));
            rtn_list.Add(new StateCode(1, "MA", "MASSACHUSETTS"));
            rtn_list.Add(new StateCode(1, "MI", "MICHIGAN"));
            rtn_list.Add(new StateCode(1, "MN", "MINNESOTA"));
            rtn_list.Add(new StateCode(1, "MS", "MISSISSIPPI"));
            rtn_list.Add(new StateCode(1, "MO", "MISSOURI"));
            rtn_list.Add(new StateCode(1, "MT", "MONTANA"));
            rtn_list.Add(new StateCode(1, "NE", "NEBRASKA"));
            rtn_list.Add(new StateCode(1, "NV", "NEVADA"));
            rtn_list.Add(new StateCode(1, "NH", "NEW HAMPSHIRE"));
            rtn_list.Add(new StateCode(1, "NJ", "NEW JERSEY"));
            rtn_list.Add(new StateCode(1, "NM", "NEW MEXICO"));
            rtn_list.Add(new StateCode(1, "NY", "NEW YORK"));
            rtn_list.Add(new StateCode(1, "NC", "NORTH CAROLINA"));
            rtn_list.Add(new StateCode(1, "ND", "NORTH DAKOTA"));
            rtn_list.Add(new StateCode(1, "OH", "OHIO"));
            rtn_list.Add(new StateCode(1, "OK", "OKLAHOMA"));
            rtn_list.Add(new StateCode(1, "OR", "OREGON"));
            rtn_list.Add(new StateCode(1, "PA", "PENNSYLVANIA"));
            rtn_list.Add(new StateCode(1, "RI", "RHODE ISLAND"));
            rtn_list.Add(new StateCode(1, "SC", "SOUTH CAROLINA"));
            rtn_list.Add(new StateCode(1, "SD", "SOUTH DAKOTA"));
            rtn_list.Add(new StateCode(1, "TN", "TENNESSEE"));
            rtn_list.Add(new StateCode(1, "TX", "TEXAS"));
            rtn_list.Add(new StateCode(1, "UT", "UTAH"));
            rtn_list.Add(new StateCode(1, "VT", "VERMONT"));
            rtn_list.Add(new StateCode(1, "VA", "VIRGINIA"));
            rtn_list.Add(new StateCode(1, "WA", "WASHINGTON"));
            rtn_list.Add(new StateCode(1, "WV", "WEST VIRGINIA"));
            rtn_list.Add(new StateCode(1, "WI", "WISCONSIN"));
            rtn_list.Add(new StateCode(1, "WY", "WYOMING"));
            rtn_list.Add(new StateCode(1, "GU", "GUAM"));
            rtn_list.Add(new StateCode(1, "PR", "PUERTO RICO"));
            rtn_list.Add(new StateCode(1, "VI", "VIRGIN ISLANDS"));
            return rtn_list;
        }
    }
}