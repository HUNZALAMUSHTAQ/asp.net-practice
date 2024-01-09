using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Shopping.Data;
using Shopping.Dtos;
using Shopping.Interfaces;
using Shopping.Models;

namespace Shopping.Service
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        
        public bool CreateProduct(int orderId, ProductDto product)
        {
            var order = _context.Orders.Include(o => o.Products).FirstOrDefault(o => o.Id == orderId);

            if (order == null)
            {
                return false;
            }

            var createdProduct = new Product
            {
                Name = product.Name,
                Price = product.Price,
                OrderId = order.Id
            };

            // Add the new product to the Products collection of the order
            order.Products.Add(createdProduct);

            // Save changes to persist the new product and the updated order
            _context.SaveChanges();

            return true;
        }

        public ProductListDto GetProducts()
        {
           var data = _context.Product.OrderBy(p=>p.Id).ToList();
           var prodListDto =  data.Select(p => new ProductDto { Id = p.Id, Name= p.Name, Price = p.Price }).ToList();
            return new ProductListDto { Products = prodListDto };
        }

        ProductDto IProductService.GetProduct(int productId)
        {
            throw new NotImplementedException();
        }

        ProductDto IProductService.GetProductByName(string productName)
        {
            throw new NotImplementedException();
        }
    }
}
