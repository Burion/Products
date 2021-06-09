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
    class ProductService
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
    }
}
