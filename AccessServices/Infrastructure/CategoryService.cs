using AccessServices.Dtos;
using AccessServices.Interfaces;
using AccessServices.Mapper;
using AutoMapper;
using DataAccess.Interfaces;
using DataAccess.Models;
using System.Collections.Generic;

namespace AccessServices.Infrastructure
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper mapper;
        private readonly IDbAccesserCategory _dbAccesser;
        
        public CategoryService(IDbAccesserCategory dbAccesser)
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

        public CategoryDto GetCategoryByName(string name)
        {
            var category = _dbAccesser.GetCategoryByName(name);

            return mapper.Map<Category, CategoryDto>(category);
        }
    }
}

