using OrderManagementSystem.Models;

namespace OrderManagementSystem.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> RegisterUserAsync(User user);
        Task<User> AuthenticateUserAsync(string username, string password);
    }
}
