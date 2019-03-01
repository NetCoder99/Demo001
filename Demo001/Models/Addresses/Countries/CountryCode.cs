//============================================================================
// John Dugger
// 02/27/2019
// Define the db fields for the Country name dropdowns/lists, etc. Keep 
// this simple as it maps to the DB Tables and changing this leads
// to migration issues in the EF, which I don't want to deal with now.
//============================================================================
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp2.Models.Addresses
{
    [Table("CountryCodes", Schema = "WEBAPP2")]
    public class CountryCode
    {
        [Key]
        public int CountryCodeId  { get; set; }

        [Required] [MaxLength(3)] [Index(IsUnique = true)]
        public string CountryAbbr { get; set; }

        [Required] [MaxLength(256)]
        public string CountryName { get; set; }

        [Required]
        public DateTime LoadDate  { get; set; }

        public CountryCode() {
            this.LoadDate = DateTime.Now;
        }
        public CountryCode(int CountryCodeId, string CountryAbbr, string CountryName)
        {
            this.CountryCodeId = CountryCodeId;
            this.CountryAbbr = CountryAbbr;
            this.CountryName = CountryName;
            this.LoadDate = DateTime.Now;
        }

        public ICollection<StateCode> StateCode { get; set; }
    }
}