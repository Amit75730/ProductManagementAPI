using ProductManagementAPI.Models;

namespace ProductManagementAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> Register(User user);
        Task<string> Login(string email, string password);
    }
}
