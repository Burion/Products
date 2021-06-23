using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Infrastructure.EfCore
{
    public class DbAccesserCategoryEF : DbAccesserEF<Category>, IDbAccesserCategory
    {

        public void AddCategory(Category category)
        {
            AddItem(category);
        }

        public void DeleteCategory(Category category)
        {
            DeleteItem(category);
        }

        public void EditCategory(Category category)
        {
            EditItem(category);
        }

        public IEnumerable<Category> GetCategories()
        {
            return GetItems();
        }

        public Category GetCategory(int id)
        {
            return GetItem(e => e.Id == id);
        }
    }
}

