using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Infrastructure.EfCore
{
    public class DbAccesserProductEF : DbAccesserEF<Product>, IDbAccesserProduct
    {
        public DbAccesserProductEF(ProductsContext context) : base(context)
        {

        }

        public void AddProduct(Product product)
        {
            AddItem(product);
        }

        public void DeleteProduct(Product product)
        {
            DeleteItem(product);
        }

        public void EditProduct(Product product)
        {
            EditItem(product);
        }

        public Product GetProduct(int id)
        {
            return GetItem(i => i.Id == id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return GetItems();
        }
    }
}
