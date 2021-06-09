using System;
using System.Collections.Generic;
using System.Text;
using AccessServices.DTOs;
using AutoMapper;
using DataAccess.Models;

namespace AccessServices.Mapper
{
    class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(pdto => pdto.CategoryName, opt => opt.MapFrom<CategoryResolver>());

            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();
        }
    }
}
