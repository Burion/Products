using AccessServices.DTOs;
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

        public CategoryDTO GetCategory(int id)
        {
            var item = _dbAccesser.GetCategory(id);
            return mapper.Map<Category, CategoryDTO>(item);
        }

        public IEnumerable<CategoryDTO> GetCategories()
        {

            var items = _dbAccesser.GetCategories();
            return mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(items);
        }

        public void AddCategory(CategoryDTO item)
        {
            _dbAccesser.AddCategory(mapper.Map<CategoryDTO, Category>(item));
        }

        public void EditCategory(CategoryDTO item)
        {
            var _item = _dbAccesser.GetCategory(item.Id);
            mapper.Map(item, _item);
            _dbAccesser.EditCategory(mapper.Map(item, _item));
        }

        public void DeleteCategory(CategoryDTO item)
        {

            var _item = _dbAccesser.GetCategory(item.Id);
            _dbAccesser.DeleteCategory(_item);
        }
    }
}

