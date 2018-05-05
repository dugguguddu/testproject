using Microsoft.EntityFrameworkCore;
using SalesMakert.Data;
using SalesMakert.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesMarket.Repo
{
    public class SalesDbContext:DbContext
    {
        public SalesDbContext(DbContextOptions<SalesDbContext> options): base(options)
        {

        }
        
        public DbSet<TokensData> TokensData { get; set; }
        public DbSet<Users> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new UsersMap(modelBuilder.Entity<Users>());
            new UserProfileMap(modelBuilder.Entity<UserProfile>());
            new ProductsMap(modelBuilder.Entity<Products>());
            new PartiesMap(modelBuilder.Entity<Parties>());
            new TokenMap(modelBuilder.Entity<Tokens>());
            new TokenDataMap(modelBuilder.Entity<TokensData>());
        }
    }
}
