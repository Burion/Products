using AccessServices.Dtos;
using System.Collections.Generic;

namespace AccessServices.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetProducts();
        void AddProduct(ProductDto product);
        void EditProduct(ProductDto product);
        void DeleteProduct(ProductDto product);
    }
}
