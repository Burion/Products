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
        IDbAccesserCategory Accesser
        {
            get
            {
                INinjectModule module = new Bindings(); 
                var kernel = new StandardKernel(module);
                return kernel.Get<IDbAccesserCategory>();
            }
        }
        public CategoryServiceUniversal()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            mapper = mappingConfig.CreateMapper();
        }

        public CategoryDTO GetCategory(int id)
        {
            using (IDbAccesserCategory dbAccesser = Accesser)
            {
                var item = dbAccesser.GetCategory(id);
                return mapper.Map<Category, CategoryDTO>(item);
            }
        }

        public IEnumerable<CategoryDTO> GetCategories()
        {
            using (IDbAccesserCategory dbAccesser = Accesser)
            {
                var items = dbAccesser.GetCategories();
                return mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(items);
            }
        }

        public void AddCategory(CategoryDTO item)
        {
            using (IDbAccesserCategory dbAccesser = Accesser)
            {
                dbAccesser.AddCategory(mapper.Map<CategoryDTO, Category>(item));
            }

        }

        public void EditCategory(CategoryDTO item)
        {
            using (IDbAccesserCategory dbAccesser = Accesser)
            {
                var _item = dbAccesser.GetCategory(item.Id);
                mapper.Map(item, _item);
                dbAccesser.EditCategory(mapper.Map(item, _item));
            }
        }

        public void DeleteCategory(CategoryDTO item)
        {
            using (IDbAccesserCategory dbAccesser = Accesser)
            {
                var _item = dbAccesser.GetCategory(item.Id);
                dbAccesser.DeleteCategory(_item);
            }
        }
    }
}

