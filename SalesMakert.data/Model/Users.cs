using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalesMakert.Data.Model
{
    public class Users:BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public virtual TokensData TokensData { get; set; }
    }
}
