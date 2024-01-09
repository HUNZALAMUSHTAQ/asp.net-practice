using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopping.Dtos;
using Shopping.Interfaces;
using Shopping.Models;

namespace Shopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<ProductListDto> GetProducts() 
        {
            var products = _productService.GetProducts();
            return Ok(products);
        }
        [HttpPost]
        public bool CreateProduct(int orderId, ProductDto product)
        {
            var prod = _productService.CreateProduct(orderId, product);
            return prod;
        }
    }
}
