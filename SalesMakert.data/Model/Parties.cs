using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalesMakert.Data.Model
{
    public class Parties:BaseEntity
    {   
        public string PartyName { get; set; }
        public string Email { get; set; }
        public string GSTNumber { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public int Pincode { get; set; }
        public string Type { get; set; }
        public decimal DiscountPercentage { get; set; } 
        [Required]
        public string Location { get; set; }
        public string UniqueCode { get; set; }
    }
}
