using AccessServices.Dtos;
using AccessServices.Helpers;
using AccessServices.Interfaces;
using AccessServices.Mapper;
using AccessServices.Ninject;
using AutoMapper;
using DataAccess;
using DataAccess.Infrastructure.EfCore;
using DataAccess.Interfaces;
using DataAccess.Models;
using Ninject;
using System;
using System.Collections.Generic;

namespace AccessServices.Infrastructure
{
    public class CategoryService: ICategoryService
    {
        readonly IMapper mapper;
     
        public CategoryService()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            mapper = mappingConfig.CreateMapper();
        }

        public CategoryDto GetCategory(int id)
        {
            using (var dbAccesser = new DbAccesserEF<Category>(BindingsHendler.GetContext()))
            { 
                var item = dbAccesser.GetItem(c => c.Id == id);

                return mapper.Map<Category, CategoryDto>(item);
            }
        }

        public IEnumerable<CategoryDto> GetCategories()
        {
            using (var dbAccesser = new DbAccesserEF<Category>(BindingsHendler.GetContext()))
            {
                var categories = dbAccesser.GetItems();

                return mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(categories);
            }
        }

        public void AddCategory(CategoryDto categoryDto)
        {
            using (var dbAccesser = new DbAccesserEF<Category>(BindingsHendler.GetContext()))
            {
                dbAccesser.AddItem(mapper.Map<CategoryDto, Category>(categoryDto));
            }   
        }

        public void EditCategory(CategoryDto categoryDto)
        {
            using (var dbAccesser = new DbAccesserEF<Category>(BindingsHendler.GetContext()))
            {
                var category = dbAccesser.GetItem(i => i.Id == categoryDto.Id);
                dbAccesser.EditItem(mapper.Map(categoryDto, category));
            }
        }

        public void DeleteCategory(CategoryDto categoryDto)
        {
            using (var dbAccesser = new DbAccesserEF<Category>(BindingsHendler.GetContext()))
            {
                var category = dbAccesser.GetItem(i => i.Id == categoryDto.Id);
                dbAccesser.DeleteItem(category);
            }
        }
    }
}