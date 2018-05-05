using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalesMakert.Data.Model
{
    public class Tokens
    {   
        [Key]
        [Required]
        public string userName { get; set; }
        public string password { get; set; }
        public string Email { get; set; }
    }
}
