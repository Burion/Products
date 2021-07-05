using DataAccess.ConfigurationsInterfaces;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.ConfigurationInfrastructure
{
    internal class CategoryEntityConfiguration : IEntityConfiguration
    {
        private readonly ModelBuilder _builder;

        public CategoryEntityConfiguration(ModelBuilder builder)
        {
            _builder = builder;
        }

        public void Configure()
        {
            _builder
                .Entity<Category>()
                .HasIndex(u => u.Name)
                .IsUnique();
            _builder
                .Entity<Category>()
                .Property(c => c.Name)
                .HasMaxLength(256);
        }
    }
}