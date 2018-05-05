using System;
using System.Collections.Generic;
using System.Text;

namespace SalesMakert.Data.Model
{
    public class Products:BaseEntity
    {
        public string ProductName { get; set; }
        public string Type { get; set; }
        public string CompanyName { get; set; }
        public string GSTNumber { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int StockCount { get; set; }
        public decimal CGST { get; set; }
        public decimal SGST { get; set; }
        public decimal StockPrize { get; set; }
        public decimal MarketPrize { get; set; }
        public string DistributerName { get; set; }
        public string DistributerId { get; set; }
        public string UniqueCode { get; set; }
    }
}
