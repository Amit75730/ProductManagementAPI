using Microsoft.EntityFrameworkCore;
using ProductManagementAPI.Data;
using ProductManagementAPI.Models;
using ProductManagementAPI.Repositories.Interfaces;

namespace ProductManagementAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product> AddProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetProductsByUserIdAsync(int userId)
        {
            return await _context.Products.Where(p => p.UserId == userId).ToListAsync();
        }
    }
}
