using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp2.Models.Account;

namespace Demo001.Common
{
    class CommonJSONProcs
    {

        // ---------------------------------------------------------------------------------------
        // messing around with Generics and JSON
        // ---------------------------------------------------------------------------------------
        public static List<T> ProcessJSONClass<T>(string json_string)
        {
            Type type = typeof(T);
            var root = JsonConvert.DeserializeObject<UserAccountRoot>(json_string);
            if (type == typeof(UserAccount))
            {
                List<UserAccount> sf_list = new List<UserAccount>();
                sf_list.AddRange(root.UserAccount);
                List<T> rtn_list = sf_list.Cast<T>().ToList();
                return rtn_list;
            }
            if (type == typeof(UserField))
            {
                List<UserAccount> root_list = new List<UserAccount>();
                List<UserField> flds_list = new List<UserField>();
                root_list.AddRange(root.UserAccount);
                flds_list.AddRange(root_list[0].UserFields);
                List<T> rtn_list = flds_list.Cast<T>().ToList();
                return rtn_list;
            }
            if (type == typeof(UserDetail))
            {
                List<UserAccount> root_list = new List<UserAccount>();
                List<UserDetail> dtls_list = new List<UserDetail>();
                root_list.AddRange(root.UserAccount);
                dtls_list.AddRange(root_list[0].UserDetails);
                List<T> rtn_list = dtls_list.Cast<T>().ToList();
                return rtn_list;
            }
            throw new Exception("Unknow type");
        }
    }
}
