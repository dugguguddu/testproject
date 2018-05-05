using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesMakert.Data.Model
{
    public class TokensData:BaseEntity
    {
        public string Token { get; set; }
        public DateTime ExpiryToken { get; set; }
        public DateTime ExpiryRefreshToken { get; set; }
        public string RefreshToken { get; set; }
        public virtual Users Users { get; set; }
        public int UsersId { get; set; }
        
    }
}
