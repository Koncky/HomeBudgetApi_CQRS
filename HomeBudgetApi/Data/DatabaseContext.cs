using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeBudgetApi_CQRS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HomeBudgetApi_CQRS.Data
{
    public class DatabaseContext : DbContext 
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Fee> Fee { get; set; }
        public DbSet<Payment> Payment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Fee>()
                .HasMany(fee => fee.Payments)
                .WithOne(feeSch => feeSch.Fee);

            modelBuilder.Entity<Payment>(e => e.Property(o => o.Month).HasColumnType("tinyint(1)").HasConversion<short>());            
            modelBuilder.Entity<Payment>(e => e.Property(o => o.Realized).HasConversion(new BoolToZeroOneConverter<Int16>()).HasColumnType("bit"));
            modelBuilder.Entity<Fee>(e => e.Property(o => o.IsArchival).HasConversion(new BoolToZeroOneConverter<Int16>()).HasColumnType("bit"));
        }
    }
}
