using ProductManagementAPI.Models;

namespace ProductManagementAPI.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> AddProduct(Product product);
        Task<IEnumerable<Product>> GetProductsByUserIdAsync(int userId);
    }
}
