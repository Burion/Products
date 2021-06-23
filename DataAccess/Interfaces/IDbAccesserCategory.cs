using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface IDbAccesserCategory : IDisposable
    {
        public void AddCategory(Category category);


        public void DeleteCategory(Category category);


        public void EditCategory(Category category);


        public IEnumerable<Category> GetCategories();

        public Category GetCategory(int id);

    }
}
