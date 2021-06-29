using AccessServices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccessServices.Interfaces
{
    public interface ICategoryService
    {
        public CategoryDto GetCategory(int id);

        public IEnumerable<CategoryDto> GetCategories();

        public void AddCategory(CategoryDto item);

        public void EditCategory(CategoryDto item);

        public void DeleteCategory(CategoryDto item);
    }
}
