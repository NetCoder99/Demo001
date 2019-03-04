using Demo001.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp2.Models.Account;

namespace Demo001.Data.TestFiles
{
    class GetTestUsersFilesLong : IGetTestData
    {
        public List<UserDetail> GetData()
        {
            string defs_dir_name = CommonFileProcs.GetLocalDirectory("TestFiles");
            string json_string = File.ReadAllText(defs_dir_name + "\\" + "UserAccountInitList.json");
            List<UserDetail> dtls_list = CommonJSONProcs.ProcessJSONClass<UserDetail>(json_string).Cast<UserDetail>().ToList();
            return dtls_list;
        }
    }
}
