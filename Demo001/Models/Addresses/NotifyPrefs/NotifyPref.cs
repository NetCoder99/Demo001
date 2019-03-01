//============================================================================
// John Dugger
// 02/27/2019
// Applied to the UI, the user will select his preference for how to be 
// notified of stuff.
//============================================================================
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp2.Models.Addresses
{
    [Table("NotifyPrefs", Schema = "WEBAPP2")]
    public class NotifyPref
    {
        [Key]
        public int NotifyPrefId { get; set; }

        [Required]
        [MaxLength(12)]
        [Index]
        public string NotifyPrefName { get; set; }

        public bool NotifyPrefChecked { get; set; }

        [Required]
        public DateTime LoadDate { get; set; }

        public NotifyPref() { }
        public NotifyPref(string npref_name)
        {
            this.NotifyPrefName = npref_name;
            this.LoadDate = DateTime.Now;
        }

    }
}
