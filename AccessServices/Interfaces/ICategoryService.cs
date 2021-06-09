using AccessServices.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccessServices.Interfaces
{
    public interface ICategoryService
    {
        public CategoryDTO GetCategory(int id);

        public IEnumerable<CategoryDTO> GetCategories();

        public void AddCategory(CategoryDTO item);

        public void EditCategory(CategoryDTO item);

        public void DeleteCategory(CategoryDTO item);
    }
}
