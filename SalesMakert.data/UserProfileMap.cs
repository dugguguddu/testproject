using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesMakert.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesMakert.Data
{
    public class UserProfileMap
    {
        public UserProfileMap(EntityTypeBuilder<UserProfile> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(n => n.Id);
            entityTypeBuilder.Property(n => n.FirstName);
            entityTypeBuilder.Property(n => n.LastName);
            entityTypeBuilder.Property(n => n.Email);
            entityTypeBuilder.Property(n => n.MobileNumeber);
            entityTypeBuilder.HasOne(n => n.Users).WithOne(n => n.UserProfile).HasForeignKey<UserProfile>(n => n.Id);
        }
    }
}
