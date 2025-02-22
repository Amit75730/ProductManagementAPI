using ProductManagementAPI.Models;

namespace ProductManagementAPI.Services.Interfaces
{
    public interface IProductService
    {
        Task<Product> AddProduct(Product product);
        Task<IEnumerable<Product>> GetProductsByUserIdAsync(int userId);
    }
}
