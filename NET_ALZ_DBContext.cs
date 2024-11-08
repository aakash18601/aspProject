using Microsoft.EntityFrameworkCore;
using NET_ALZ.Models;
using System;

namespace NET_ALZ.EntityFramework
{
    public class NET_ALZ_DBContext : DbContext
    {
        public NET_ALZ_DBContext(DbContextOptions<NET_ALZ_DBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<UserModel>()
            .HasKey(d => d.UserId);
            modelBuilder.Entity<UserModel>().Property(x => x.UserId).ValueGeneratedOnAdd();

            modelBuilder
           .Entity<UserLogs>()
           .HasKey(d => d.ID);
            modelBuilder.Entity<UserLogs>().Property(x => x.ID).ValueGeneratedOnAdd();

            modelBuilder
           .Entity<MappingModel>()
           .HasKey(d => d.Id);
            modelBuilder.Entity<MappingModel>().Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<CurrencyModel>().Property(x => x.BHD_ExRate).HasPrecision(12, 5);
            modelBuilder.Entity<CurrencyModel>().Property(x => x.LOC_VAT_PER).HasPrecision(5, 2);
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<UserLogs> UserLogs { get; set; }
        public DbSet<EntityModel> Entities { get; set; }
        public DbSet<CurrencyModel> Currencies { get; set; }
        public DbSet<MappingModel> Mappings { get; set; }
    }
}
