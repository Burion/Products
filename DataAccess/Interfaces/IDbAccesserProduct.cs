using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface IDbAccesserProduct
    {
        public void AddProduct(Product product);


        public void DeleteProduct(Product product);


        public void EditProduct(Product product);


        public IEnumerable<Product> GetProducts();

        public Product GetProduct(int id);
    }
}
