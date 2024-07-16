using OrderManagementSystem.Models;

namespace OrderManagementSystem.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> CreateCustomerAsync(Customer customer);
        Task<IEnumerable<Order>> GetCustomerOrdersAsync(int customerId);
    }
}
