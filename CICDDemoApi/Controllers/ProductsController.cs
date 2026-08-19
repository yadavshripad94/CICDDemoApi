using CICDDemoApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CICDDemoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private static readonly List<Product> Products = new()
        {
            new Product
            {
                Id = 1,
                Name = "Laptop",
                Price = 65000,
                Category = "Electronics"
            },
            new Product
            {
                Id = 2,
                Name = "Mobile",
                Price = 30000,
                Category = "Electronics"
            },
            new Product
            {
                Id = 3,
                Name = "Keyboard",
                Price = 1500,
                Category = "Accessories"
            }
        };

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(Products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound(new
                {
                    message = "Product not found"
                });
            }

            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            product.Id = Products.Max(p => p.Id) + 1;

            Products.Add(product);

            return CreatedAtAction(
                nameof(GetProduct),
                new { id = product.Id },
                product);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product product)
        {
            var existingProduct = Products.FirstOrDefault(p => p.Id == id);

            if (existingProduct == null)
            {
                return NotFound(new
                {
                    message = "Product not found"
                });
            }

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Category = product.Category;

            return Ok(existingProduct);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound(new
                {
                    message = "Product not found"
                });
            }

            Products.Remove(product);

            return Ok(new
            {
                message = "Product deleted successfully"
            });
        }
    }
}
