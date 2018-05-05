using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesMakert.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesMakert.Data
{
    public class TokenMap
    {
        public TokenMap(EntityTypeBuilder<Tokens> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(n => n.userName);
            entityTypeBuilder.Property(n => n.password).IsRequired();
            entityTypeBuilder.Property(n => n.Email);
        }
    }
}
