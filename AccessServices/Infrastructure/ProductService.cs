﻿using AccessServices.Interfaces;
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

        public IEnumerable<ProductDto> GetProducts()
        {
            using (var dbAccesser = new DbAccesserEF<Product>(BindingsHendler.GetContext()))
            {
                var dbItems = dbAccesser.GetItems();
                return mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(dbItems);
            }
        }

        public void AddProduct(ProductDto product)
        {
            using (var dbAccesser = new DbAccesserEF<Product>(BindingsHendler.GetContext()))
            {
                var dbAccesserCategory = new DbAccesserEF<Category>(BindingsHendler.GetContext());
                var category = dbAccesserCategory.GetItem(c => c.Name == product.CategoryName);
                var newProduct = mapper.Map<ProductDto, Product>(product);
                newProduct.CategoryId = category.Id;
                dbAccesser.AddItem(newProduct);
            }
        }

        public void EditProduct(ProductDto product)
        {
            using (var dbAccesser = new DbAccesserEF<Product>(BindingsHendler.GetContext()))
            {
                var dbAccesserCategory = new DbAccesserEF<Category>(BindingsHendler.GetContext());
                var categ = dbAccesserCategory.GetItem(c => c.Name == product.CategoryName);
                var prod = dbAccesser.GetItem(p => p.Id == product.Id);
                var newProduct = mapper.Map<ProductDto, Product>(product);
                newProduct.CategoryId = categ.Id;

                var origItem = dbAccesser.GetItem(i => i.Id == product.Id);
                mapper.Map(product, origItem);
                origItem.CategoryId = categ.Id;
                dbAccesser.EditItem(origItem);
            }
        }

        public void DeleteProduct(ProductDto product)
        {
            using (var dbAccesser = new DbAccesserEF<Product>(BindingsHendler.GetContext()))
            {
                var item = dbAccesser.GetItem(i => i.Id == product.Id);
                dbAccesser.DeleteItem(item);
            }
        }
    }
}