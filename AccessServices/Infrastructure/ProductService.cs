using AccessServices.Interfaces;
using AutoMapper;
using DataAccess.Interfaces;
using DataAccess.Infrastructure.EfCore;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using AccessServices.Mapper;
using AccessServices.DTOs;

namespace AccessServices.Infrastructure
{
    public class ProductService
    {
        readonly IDbAccesser<Product> dbAccesser;
        readonly IMapper mapper;
        public ProductService()
        {
            dbAccesser = new DbAccesserEF<Product>();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            mapper = mappingConfig.CreateMapper();
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            var dbItems = dbAccesser.GetItems();
            return mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(dbItems);
        }

        public void AddProduct(ProductDTO product, CategoryDTO category)
        {
            var dbAccesserCategory = new DbAccesserEF<Category>();
            var categ = dbAccesserCategory.GetItem(c => c.Name == category.Name);
            var newProduct = mapper.Map<ProductDTO, Product>(product);
            newProduct.CategoryId = categ.Id;
            dbAccesser.AddItem(newProduct);
        }

        public void AddProduct(ProductDTO product)
        {
            dbAccesser.AddItem(mapper.Map<ProductDTO, Product>(product));
        }

        public void EditProduct(ProductDTO product)
        {
            var dbAccesserCategory = new DbAccesserEF<Category>();
            var categ = dbAccesserCategory.GetItem(c => c.Name == product.CategoryName);
            var prod = dbAccesser.GetItem(p => p.Id == product.Id);
            var newProduct = mapper.Map<ProductDTO, Product>(product);
            newProduct.Category = categ;
            dbAccesser.EditItem(prod, newProduct);
        }

    }
}
