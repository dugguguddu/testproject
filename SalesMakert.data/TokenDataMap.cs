using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesMakert.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesMakert.Data
{
    public class TokenDataMap
    {
        public TokenDataMap(EntityTypeBuilder<TokensData> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(n => n.Id);
            entityTypeBuilder.Property(n => n.Token).IsRequired();
            entityTypeBuilder.Property(n => n.RefreshToken).IsRequired();
            entityTypeBuilder.Property(n => n.ExpiryToken).IsRequired();
            entityTypeBuilder.Property(n => n.ExpiryRefreshToken).IsRequired();
            entityTypeBuilder.HasOne(n => n.Users).WithOne(n => n.TokensData).HasForeignKey<TokensData>(n => n.UsersId);
        }
    }
}
