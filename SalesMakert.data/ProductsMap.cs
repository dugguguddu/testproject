using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesMakert.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesMakert.Data
{
    public class ProductsMap
    {
        public ProductsMap(EntityTypeBuilder<Products> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(n => n.Id);
            entityTypeBuilder.Property(n => n.ProductName).IsRequired();
            entityTypeBuilder.Property(n => n.Type);
            entityTypeBuilder.Property(n => n.CompanyName).IsRequired();
            entityTypeBuilder.Property(n => n.ManufacturingDate).IsRequired();
            entityTypeBuilder.Property(n => n.ExpiryDate).IsRequired();
            entityTypeBuilder.Property(n => n.StockCount).IsRequired();
            entityTypeBuilder.Property(n => n.GSTNumber).IsRequired();
            entityTypeBuilder.Property(n => n.CGST).IsRequired();
            entityTypeBuilder.Property(n => n.SGST);
            entityTypeBuilder.Property(n => n.MarketPrize);
            entityTypeBuilder.Property(n => n.StockPrize);
            entityTypeBuilder.Property(n => n.AddedDate);
            entityTypeBuilder.Property(n => n.LastUpdate);
            entityTypeBuilder.Property(n => n.DistributerId);
            entityTypeBuilder.Property(n => n.DistributerName);
            entityTypeBuilder.Property(n => n.UniqueCode).IsRequired();
        }
    }
}
