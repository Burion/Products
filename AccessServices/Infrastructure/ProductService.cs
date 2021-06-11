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

        readonly IMapper mapper;
        public ProductService()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            mapper = mappingConfig.CreateMapper();
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            using (var dbAccesser = new DbAccesserEF<Product>())
            {
                var dbItems = dbAccesser.GetItems();
                return mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(dbItems);
            }
        }

        public void AddProduct(ProductDTO product)
        {
            using (var dbAccesser = new DbAccesserEF<Product>())
            {
                var dbAccesserCategory = new DbAccesserEF<Category>();
                var categ = dbAccesserCategory.GetItem(c => c.Name == product.CategoryName);
                var newProduct = mapper.Map<ProductDTO, Product>(product);
                newProduct.CategoryId = categ.Id;
                dbAccesser.AddItem(newProduct);
            }
        }

        public void EditProduct(ProductDTO product)
        {
            using (var dbAccesser = new DbAccesserEF<Product>())
            {
                var dbAccesserCategory = new DbAccesserEF<Category>();
                var categ = dbAccesserCategory.GetItem(c => c.Name == product.CategoryName);
                var prod = dbAccesser.GetItem(p => p.Id == product.Id);
                var newProduct = mapper.Map<ProductDTO, Product>(product);
                newProduct.CategoryId = categ.Id;

                var origItem = dbAccesser.GetItem(i => i.Id == product.Id);
                mapper.Map(product, origItem);
                origItem.CategoryId = categ.Id;
                dbAccesser.EditItem(origItem);
            }
        }

        public void DeleteProduct(ProductDTO product)
        {
            using (var dbAccesser = new DbAccesserEF<Product>())
            {
                var item = dbAccesser.GetItem(i => i.Id == product.Id);
                dbAccesser.DeleteItem(item);
            }
        }

    }
}
