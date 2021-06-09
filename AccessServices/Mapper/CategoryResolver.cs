using System;
using System.Collections.Generic;
using System.Text;
using AccessServices.DTOs;
using AutoMapper;
using DataAccess.Models;

namespace AccessServices.Mapper
{
    class CategoryResolver : IValueResolver<Product, ProductDTO, string>
    {
        public string Resolve(Product source, ProductDTO destination, string member, ResolutionContext context)
        {
            return source.Category.Name;
        }
    }
    
}

