using AccessServices.DTOs;
using AccessServices.Mapper;
using AutoMapper;
using DataAccess.Infrastructure.Dapper.Partial;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccessServices.Infrastructure
{
    public class CategoryServiceADO
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
        public void AddCategory(CategoryDTO item)
        {
            dbAccesser.AddCategory(mapper.Map<CategoryDTO, Category>(item));
        }

        public void DeleteCategory(CategoryDTO item)
        {
            dbAccesser.DeleteCategory(mapper.Map<CategoryDTO, Category>(item));
        }

        public void EditCategory(CategoryDTO item)
        {
            dbAccesser.EditCategory(mapper.Map<CategoryDTO, Category>(item));
        }

        public IEnumerable<CategoryDTO> GetCategories()
        {
            return mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(dbAccesser.GetCategories());
        }

        public CategoryDTO GetCategory(int id)
        {
            return mapper.Map<Category, CategoryDTO>(dbAccesser.GetCategory(id));
        }
    }
}
