using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Collections.Specialized;

namespace DataAccess
{
    public class ProductsContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>()
                .HasIndex(u => u.Name)
                .IsUnique();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {   

            var connectionString = ConfigurationManager.AppSettings.Get("connectionString") ?? "Server=localhost;Database=productswpf;Trusted_Connection=True;";
            options
                .UseLazyLoadingProxies()
                .UseSqlServer(connectionString);
        }
    }
}
