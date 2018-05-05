using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesMakert.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesMakert.Data
{
    public class UsersMap
    {
        public UsersMap(EntityTypeBuilder<Users> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(n=>n.Id);
            entityTypeBuilder.Property(n => n.UserName);
            entityTypeBuilder.Property(n => n.Password);
            entityTypeBuilder.Property(n => n.Role);
        }
    }
}
