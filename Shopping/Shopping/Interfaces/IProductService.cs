using Shopping.Dtos;
using Shopping.Models;

namespace Shopping.Interfaces
{
    public interface IProductService
    {
        ProductListDto GetProducts();
        ProductDto GetProduct(int productId);
        ProductDto GetProductByName(string productName);

        bool CreateProduct(int orderId, ProductDto product);
    }
}
