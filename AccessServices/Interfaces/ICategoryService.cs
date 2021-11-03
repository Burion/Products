using AccessServices.Dtos;
using System.Collections.Generic;

namespace AccessServices.Interfaces
{
    public interface ICategoryService
    {
        CategoryDto GetCategory(int id);
        IEnumerable<CategoryDto> GetCategories();
        void AddCategory(CategoryDto item);
        void EditCategory(CategoryDto item);
        void DeleteCategory(CategoryDto item);
        CategoryDto GetCategoryByName(string name);
    }
}
