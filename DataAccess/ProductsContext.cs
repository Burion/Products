using Microsoft.EntityFrameworkCore;
using DataAccess.Models;
using System.Configuration;
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
            const string ConnectionString = "Server=localhost;Database=productswpf;Trusted_Connection=True;";
            var connectionString = ConfigurationManager.AppSettings.Get("connectionString") ?? ConnectionString;
            options
                .UseLazyLoadingProxies()
                .UseSqlServer(connectionString);
        }
    }
}
