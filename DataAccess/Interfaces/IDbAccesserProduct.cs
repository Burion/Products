using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface IDbAccesserProduct
    {
        void AddProduct(Product product);
        void DeleteProduct(Product product);
        void EditProduct(Product product);
        IEnumerable<Product> GetProducts();
        Product GetProduct(int id);
    }
}
