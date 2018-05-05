using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalesMakert.Data.Model
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime AddedDate { get; set; }
        [Required]
        public DateTime LastUpdate { get; set; }
        public string IPAddress { get; set; }
    }
}
