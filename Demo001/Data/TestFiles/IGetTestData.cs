using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp2.Models.Account;

namespace Demo001.Data.TestFiles
{
    interface IGetTestData
    {
        List<UserDetail> GetData();
    }
}
