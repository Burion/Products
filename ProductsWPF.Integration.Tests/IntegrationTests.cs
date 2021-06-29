using AccessServices.Dtos;
using AccessServices.Interfaces;
using DataAccess;
using Ninject;
using Ninject.Modules;
using ProductsWPF.Integration.Tests.Ninject;
using ProductsWPF.IoC;
using System;
using System.Linq;
using Xunit;

namespace ProductsWPF.Integration.Tests
{
    public class IntegrationTests
    {
        StandardKernel kernel;
        public IntegrationTests()
        {
            var module = new Bindings();
            kernel = new StandardKernel(module);
        }

        [Fact]
        public void AddingCategoryRecord()
        {
            var service = kernel.Get<ICategoryService>();
            var category = new CategoryDto() { Name = "Test" };
            service.AddCategory(category);
            var categories = service.GetCategories();

            bool exists = categories.Select(c => c.Name).Contains("Test");

            Assert.True(exists);
        }

        [Fact]
        public void DeletingCategoryRecord()
        {
            var service = kernel.Get<ICategoryService>();
            service.DeleteCategory(new CategoryDto() { Id = -1 });
            var categories = service.GetCategories();

            bool exists = categories.Select(c => c.Id).Contains(-1);

            Assert.False(exists);
        }
    }
}