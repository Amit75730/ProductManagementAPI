using Microsoft.EntityFrameworkCore;
using ProductManagementAPI.Data;
using ProductManagementAPI.Models;
using ProductManagementAPI.Repositories.Interfaces;

namespace ProductManagementAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> Register(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> Login(string email, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
