using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Collections.Specialized;
using DataAccess.ConfigurationInfrastructure;

namespace DataAccess
{
    public class ProductsContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var categoryConfiguration = new CategoryEntityConfiguration(builder);
            categoryConfiguration.Configure();

            var productConfiguration = new ProductEntityConfiguration(builder);
            productConfiguration.Configure();
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
