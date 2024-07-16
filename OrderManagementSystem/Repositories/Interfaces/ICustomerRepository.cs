using OrderManagementSystem.Models;

namespace OrderManagementSystem.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> AddAsync(Customer customer);
        Task<IEnumerable<Order>> GetCustomerOrdersAsync(int customerId);
    }
}
