using Org.BouncyCastle.Crypto.Generators;
using BCrypt.Net;
using ProductManagementAPI.Helpers;
using ProductManagementAPI.Models;
using ProductManagementAPI.Repositories.Interfaces;
using ProductManagementAPI.Services.Interfaces;

namespace ProductManagementAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtHelper _jwtHelper;

        public UserService(IUserRepository userRepository, JwtHelper jwtHelper)
        {
            _userRepository = userRepository;
            _jwtHelper = jwtHelper;
        }

        public async Task<User> Register(User user)
        {
            var existingUser = await _userRepository.Login(user.Email, null);
            if (existingUser != null)
            {
                throw new ArgumentException("Email is already registered.");
            }
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password); // Hash password
            return await _userRepository.Register(user);
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _userRepository.Login(email, password);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
                return null; // Invalid credentials

            return _jwtHelper.GenerateToken(user.Id); // Generate JWT token
        }

    }
}
