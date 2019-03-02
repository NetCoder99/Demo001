using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp2.Models.Addresses
{
    interface IGetStates
    {
        List<StateCode> GetStates();
        int CountryCode { get; }
    }
}
