//============================================================================
// John Dugger
// 02/27/2019
// Define the UserAccount / UserDetails fields, use Code First to create 
// and popluate database. 
//============================================================================
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp2.Models.Account
{

    [Table("UserFields", Schema = "WEBAPP2")]
    public class UserField
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Key { get; set; }
        public string Length { get; set; }
        public override string ToString()
        {
            return Name + "," + Type + "," + Length;
        }
    }

    [Table("UserDetails", Schema = "WEBAPP2")]
    public class UserDetail
    {
        public int UserDetailId { get; set; }
        [Required]
        [MaxLength(50)]
        [Index]
        public string Password { get; set; }
        [Required]
        [MaxLength(50)]
        [Index]
        public string Email { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public string Phone { get; set; }
        public int PrefEmail { get; set; }
        public int PrefText { get; set; }
        public override string ToString()
        {
            return FirstName + "," + LastName + "," + Email;
        }
    }

    // note: need these for the NewtonSoft json parser
    public class UserAccount
    {
        public List<UserField> UserFields { get; set; }
        public List<UserDetail> UserDetails { get; set; }
    }

    public class UserAccountRoot
    {
        public List<UserAccount> UserAccount { get; set; }
    }
}
