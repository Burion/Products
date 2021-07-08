using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Microsoft.EntityFrameworkCore.InMemory;
using DataAccess.Models;

namespace DataAccess
{
    public class ProductsContextInMemory : ProductsContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options
                .UseLazyLoadingProxies()
                .UseInMemoryDatabase("productswpf");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder
                .Entity<Category>()
                .HasData(
                new Category() { Id = -1, Name = "Sample1" },
                new Category() { Id = -2, Name = "Sample2" }
                );
        }
    }
}
