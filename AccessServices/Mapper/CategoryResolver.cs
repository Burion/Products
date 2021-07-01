using System;
using System.Collections.Generic;
using System.Text;
using AccessServices.Dtos;
using AutoMapper;
using DataAccess.Models;

namespace AccessServices.Mapper
{
    class CategoryResolver : IValueResolver<Product, ProductDto, string>
    {
        public string Resolve(Product source, ProductDto destination, string member, ResolutionContext context)
        {
            return source.Category.Name;
        }
    }
}

