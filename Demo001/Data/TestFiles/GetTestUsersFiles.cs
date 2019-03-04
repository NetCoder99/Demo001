using Demo001.Common;
using Demo001.Data.TestFiles;
using Demo001.DataConnections;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp2.Models.Account;

namespace Demo001.Data.TestFiles
{
    class GetTestUsersFiles : IGetTestData
    {
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public static void TestJsonParse()
        {
            string defs_dir_name = CommonFileProcs.GetLocalDirectory("TestFiles");
            string json_string;
            json_string = File.ReadAllText(defs_dir_name + "\\" + "UserAccountInitListShort.json");
            List<UserDetail> dtls_list = CommonJSONProcs.ProcessJSONClass<UserDetail>(json_string).Cast<UserDetail>().ToList();
            CommonFileProcs.DisplayList(dtls_list);
        }

        public List<UserDetail> GetData()
        {
            string defs_dir_name = CommonFileProcs.GetLocalDirectory("TestFiles");
            string json_string = File.ReadAllText(defs_dir_name + "\\" + "UserAccountInitListShort.json");
            List<UserDetail> dtls_list = CommonJSONProcs.ProcessJSONClass<UserDetail>(json_string).Cast<UserDetail>().ToList();
            return dtls_list;
        }


        //string json_string = File.ReadAllText(defs_dir_name + "\\" + "UserAccountInitListShort.json");
        //List<UserAccount> l0 = CommonJSONProcs.ProcessJSONClass<UserAccount>(json_string).Cast<UserAccount>().ToList();
        //CommonFileProcs.DisplayList(l0);

        //json_string = File.ReadAllText(defs_dir_name + "\\" + "UserAccountInitListShort.json");
        //List<UserField> flds_list = CommonJSONProcs.ProcessJSONClass<UserField>(json_string).Cast<UserField>().ToList();
        //CommonFileProcs.DisplayList(flds_list);



    }
}
