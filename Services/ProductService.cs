using ProductManagementAPI.Models;
using ProductManagementAPI.Repositories.Interfaces;
using ProductManagementAPI.Services.Interfaces;

namespace ProductManagementAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> AddProduct(Product product)
        {
            return await _productRepository.AddProduct(product);
        }

        public async Task<IEnumerable<Product>> GetProductsByUserIdAsync(int userId)
        {
            return await _productRepository.GetProductsByUserIdAsync(userId);
        }
    }
}
