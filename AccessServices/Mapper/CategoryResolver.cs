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

