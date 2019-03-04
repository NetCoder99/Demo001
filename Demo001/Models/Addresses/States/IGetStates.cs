//============================================================================
// John Dugger
// 02/27/2019
// Working with dependency injection requires an interface. This interface 
// will support the processes related to loading and managing the dropdown 
// lists for the states/provinces in the USA, Canada and Mexico.
//============================================================================
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
