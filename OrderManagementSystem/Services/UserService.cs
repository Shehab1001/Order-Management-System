using OrderManagementSystem.Models;
using OrderManagementSystem.Repositories.Interfaces;
using OrderManagementSystem.Services.Interfaces;

namespace OrderManagementSystem.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> RegisterUserAsync(User user)
        {

            return await _userRepository.AddAsync(user);
        }

        public async Task<User> AuthenticateUserAsync(string username, string password)
        {

            return await _userRepository.AuthenticateAsync(username, password);
        }
    }
}
