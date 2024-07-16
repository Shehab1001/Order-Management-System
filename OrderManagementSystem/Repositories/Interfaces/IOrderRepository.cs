using System.Collections.Generic;
using System.Threading.Tasks;
using OrderManagementSystem.Models;

namespace OrderManagementSystem.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> AddAsync(Order order);
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order> GetByIdAsync(int orderId);
        Task UpdateStatusAsync(int orderId, string status);
    }
}
