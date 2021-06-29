using AccessServices.Dtos;
using AccessServices.Interfaces;
using AccessServices.Mapper;
using AccessServices.Ninject;
using AutoMapper;
using DataAccess.Infrastructure.EfCore;
using DataAccess.Interfaces;
using DataAccess.Models;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AccessServices.Infrastructure
{
    public class CategoryServiceUniversal : ICategoryService
    {
        readonly IMapper mapper;
        readonly IDbAccesserCategory _dbAccesser;
        
        public CategoryServiceUniversal(IDbAccesserCategory dbAccesser)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            mapper = mappingConfig.CreateMapper();
            _dbAccesser = dbAccesser;
        }

        public CategoryDto GetCategory(int id)
        {
            var item = _dbAccesser.GetCategory(id);
            return mapper.Map<Category, CategoryDto>(item);
        }

        public IEnumerable<CategoryDto> GetCategories()
        {

            var items = _dbAccesser.GetCategories();
            return mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(items);
        }

        public void AddCategory(CategoryDto item)
        {
            _dbAccesser.AddCategory(mapper.Map<CategoryDto, Category>(item));
        }

        public void EditCategory(CategoryDto item)
        {
            var _item = _dbAccesser.GetCategory(item.Id);
            mapper.Map(item, _item);
            _dbAccesser.EditCategory(mapper.Map(item, _item));
        }

        public void DeleteCategory(CategoryDto item)
        {

            var _item = _dbAccesser.GetCategory(item.Id);
            _dbAccesser.DeleteCategory(_item);
        }
    }
}

