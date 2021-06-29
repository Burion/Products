using AccessServices.Dtos;
using AccessServices.Interfaces;
using AccessServices.Mapper;
using AutoMapper;
using DataAccess.Infrastructure.Dapper.Partial;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccessServices.Infrastructure
{
    public class CategoryServiceDapper : ICategoryService
    {
        DbAccesserCategoryDapper dbAccesser;
        readonly IMapper mapper;
        public CategoryServiceDapper()
        {
            dbAccesser = new DbAccesserCategoryDapper();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            mapper = mappingConfig.CreateMapper();
        }
        public void AddCategory(CategoryDto item)
        {
            dbAccesser.AddCategory(mapper.Map<CategoryDto, Category>(item));
        }

        public void DeleteCategory(CategoryDto item)
        {
            dbAccesser.DeleteCategory(mapper.Map<CategoryDto, Category>(item));
        }

        public void EditCategory(CategoryDto item)
        {
            dbAccesser.EditCategory(mapper.Map<CategoryDto, Category>(item));
        }

        public IEnumerable<CategoryDto> GetCategories()
        {
            return mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(dbAccesser.GetCategories());
        }

        public CategoryDto GetCategory(int id)
        {
            return mapper.Map<Category, CategoryDto>(dbAccesser.GetCategory(id));
        }
    }
}
