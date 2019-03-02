//============================================================================
// John Dugger
// 02/27/2019
// Mostly for the new user create page.
//============================================================================
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp2.Models.Account
{
    [Table("UserAccounts", Schema = "WEBAPP2")]
    public class UserAccount
    {
        [Key]
        public int UserAccountId { get; set; }

        [Required]
        [MaxLength(50)]
        [Index]
        public string EmailAddress { get; set; }

        [Required]
        [MaxLength(50)]
        [Index]
        public string PassWord { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string DisplayName { get; set; }

        [MaxLength(50)]
        public string PhoneNumber { get; set; }

        public bool PrefEmail { get; set; }

        public bool PrefText { get; set; }


    }
}