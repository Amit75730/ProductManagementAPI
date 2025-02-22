using ProductManagementAPI.Models;

namespace ProductManagementAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Register(User user);
        Task<User> Login(string email, string password);
    }
}
