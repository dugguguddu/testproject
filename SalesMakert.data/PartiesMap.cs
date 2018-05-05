using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesMakert.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesMakert.Data
{
    public class PartiesMap
    {
        public PartiesMap(EntityTypeBuilder<Parties> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(n => n.Id);
            entityTypeBuilder.Property(n => n.PartyName).IsRequired();
            entityTypeBuilder.Property(n => n.Email);
            entityTypeBuilder.Property(n => n.Location).IsRequired();
            entityTypeBuilder.Property(n => n.Pincode).IsRequired();
            entityTypeBuilder.Property(n => n.MobileNumber).IsRequired();
            entityTypeBuilder.Property(n => n.PhoneNumber).IsRequired();
            entityTypeBuilder.Property(n => n.GSTNumber).IsRequired();
            entityTypeBuilder.Property(n => n.Type).IsRequired();
            entityTypeBuilder.Property(n => n.DiscountPercentage);
        }
    }
}
