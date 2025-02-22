using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManagementAPI.Models;
using ProductManagementAPI.Services.Interfaces;
using System.Security.Claims;

namespace ProductManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            product.UserId = userId;
            var createdProduct = await _productService.AddProduct(product);

            return Ok(new { message = "Product added successfully", productId = createdProduct.Id });
        }

        [HttpGet("my-products")]
        public async Task<IActionResult> GetProducts()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized("User ID not found in token.");

            int userId = int.Parse(userIdClaim.Value);
            var products = await _productService.GetProductsByUserIdAsync(userId);

            return Ok(products);
        }
    }
}
