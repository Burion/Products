using DataAccess.ConfigurationsInterfaces;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.ConfigurationInfrastructure
{
    class ProductEntityConfiguration : IEntityConfiguration
    {
        private readonly ModelBuilder _builder;
        public ProductEntityConfiguration(ModelBuilder builder)
        {
            _builder = builder;
        }

        public void Configure()
        {
            _builder.Entity<Product>()
                .Property(c => c.Name)
                .HasMaxLength(256);

            _builder.Entity<Product>()
                .Property(c => c.Description)
                .HasMaxLength(256);
        }
    }
}
