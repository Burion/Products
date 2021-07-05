using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface IDbAccesserCategory
    {
        void AddCategory(Category category);
        void DeleteCategory(Category category);
        void EditCategory(Category category);
        IEnumerable<Category> GetCategories();
        Category GetCategory(int id);
        Category GetCategoryByName(string name);
    }
}
