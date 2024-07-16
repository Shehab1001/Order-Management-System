using System.Threading.Tasks;
using OrderManagementSystem.Models;

namespace OrderManagementSystem.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> AddAsync(User user);
        Task<User> GetByUsernameAsync(string username);
        Task<User> AuthenticateAsync(string username, string password);
    }
}
