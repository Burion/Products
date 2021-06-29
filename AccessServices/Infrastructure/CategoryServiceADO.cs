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
    public class CategoryServiceADO : ICategoryService
    {
        DbAccesserCategoryADO dbAccesser;
        readonly IMapper mapper;

        public CategoryServiceADO()
        {
            dbAccesser = new DbAccesserCategoryADO();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            mapper = mappingConfig.CreateMapper();
        }

        public void AddCategory(CategoryDto categoryDto)
        {
            var category = mapper.Map<CategoryDto, Category>(categoryDto);
            dbAccesser.AddCategory(category);
        }

        public void DeleteCategory(CategoryDto categoryDto)
        {
            var category = mapper.Map<CategoryDto, Category>(categoryDto);
            dbAccesser.DeleteCategory(category);
        }

        public void EditCategory(CategoryDto categoryDto)
        {
            var category = mapper.Map<CategoryDto, Category>(categoryDto);
            dbAccesser.EditCategory(category);
        }

        public IEnumerable<CategoryDto> GetCategories()
        {
            var categories = dbAccesser.GetCategories();
            return mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(categories);
        }

        public CategoryDto GetCategory(int id)
        {
            var category = dbAccesser.GetCategory(id);
            return mapper.Map<Category, CategoryDto>(category);
        }
    }
}