using AccessServices.Interfaces;
using AutoMapper;
using DataAccess.Interfaces;
using DataAccess.Infrastructure.EfCore;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using AccessServices.Mapper;
using AccessServices.Dtos;
using AccessServices.Helpers;

namespace AccessServices.Infrastructure
{
    public class ProductService : IProductService
    {

        private readonly IMapper mapper;
        private readonly IDbAccesserProduct _dbAccesserProducts;
        private readonly IDbAccesserCategory _dbAccesserCategory;
        public ProductService(IDbAccesserProduct dbAccesserProduct, IDbAccesserCategory dbAccesserCategory)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            mapper = mappingConfig.CreateMapper();
            _dbAccesserProducts = dbAccesserProduct;
            _dbAccesserCategory = dbAccesserCategory;
        }

        public IEnumerable<ProductDto> GetProducts()
        {
            var dbItems = _dbAccesserProducts.GetProducts();

            return mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(dbItems);
        }

        public void AddProduct(ProductDto product)
        {
            var category = _dbAccesserCategory.GetCategoryByName(product.CategoryName);
            var newProduct = mapper.Map<ProductDto, Product>(product);
            newProduct.CategoryId = category.Id;

            _dbAccesserProducts.AddProduct(newProduct);
        }

        public void EditProduct(ProductDto product)
        {
            var category = _dbAccesserCategory.GetCategoryByName(product.CategoryName);
            var editedProduct = _dbAccesserProducts.GetProduct(product.Id);
            var newProduct = mapper.Map<ProductDto, Product>(product);
            newProduct.CategoryId = category.Id;

            var originalItem = _dbAccesserProducts.GetProduct(product.Id);
            mapper.Map(product, originalItem);
            originalItem.CategoryId = category.Id;

            _dbAccesserProducts.EditProduct(originalItem);
        }

        public void DeleteProduct(ProductDto product)
        {
            var productToDelete = _dbAccesserProducts.GetProduct(product.Id);
            _dbAccesserProducts.DeleteProduct(productToDelete);
        }
    }
}