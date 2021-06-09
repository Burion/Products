using AccessServices.DTOs;
using AccessServices.Interfaces;
using AccessServices.Mapper;
using AutoMapper;
using DataAccess.Infrastructure.EfCore;
using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;

namespace AccessServices.Infrastructure
{
    public class CategoryService: ICategoryService
    {
        readonly IDbAccesser<Category> dbAccesser;
        readonly IMapper mapper;
        public CategoryService()
        {
            dbAccesser = new DbAccesserEF<Category>();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            mapper = mappingConfig.CreateMapper();
        }

        public CategoryDTO GetCategory(int id)
        {
            var item = dbAccesser.GetItem(c => c.Id == id);
            return mapper.Map<Category, CategoryDTO>(item);
        }

        public IEnumerable<CategoryDTO> GetCategories()
        {
            var items = dbAccesser.GetItems();
            return mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(items);
        }

        public void AddCategory(CategoryDTO item)
        {
            
            
            dbAccesser.AddItem(mapper.Map<CategoryDTO, Category>(item));
            
        }

        public void EditCategory(CategoryDTO item)
        {
            var _item = dbAccesser.GetItem(i => i.Id == item.Id);
            mapper.Map(item, _item);
            dbAccesser.EditItem(mapper.Map(item, _item));
        }

        public void DeleteCategory(CategoryDTO item)
        {
            var _item = dbAccesser.GetItem(i => i.Id == item.Id);
            dbAccesser.DeleteItem(_item);
        }
    }
}
