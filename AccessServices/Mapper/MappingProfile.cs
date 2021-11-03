using System;
using System.Collections.Generic;
using System.Text;
using AccessServices.Dtos;
using AutoMapper;
using DataAccess.Models;

namespace AccessServices.Mapper
{
    internal class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(pdto => pdto.CategoryName, opt => opt.MapFrom<CategoryResolver>());

            CreateMap<ProductDto, Product>();
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
        }
    }
}
