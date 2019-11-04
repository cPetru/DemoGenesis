using System;
using System.ComponentModel.DataAnnotations;

namespace ContactsApi.Models
{
    public class Address : BaseEntity
    {
        [Required]
        public string Country { get; set; }
        [Required]
        public int ZipCode { get; set; }
        public string Town { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public int StreetNumber { get; set; }
        public int? POBox { get; set; }
    }
}