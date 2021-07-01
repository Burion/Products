using AccessServices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccessServices.Interfaces
{
    public interface IProductService
    {
        public IEnumerable<ProductDto> GetProducts();
        public void AddProduct(ProductDto product);
        public void EditProduct(ProductDto product);
        public void DeleteProduct(ProductDto product);
    }
}
