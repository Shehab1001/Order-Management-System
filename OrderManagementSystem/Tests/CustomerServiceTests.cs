using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Data;
using OrderManagementSystem.Models;
using OrderManagementSystem.Repositories;
using OrderManagementSystem.Services;
using Xunit;

public class CustomerServiceTests
{
    private readonly CustomerService _customerService;
    private readonly OrderManagementDbContext _context;

    public CustomerServiceTests()
    {
        var options = new DbContextOptionsBuilder<OrderManagementDbContext>()
            .UseInMemoryDatabase(databaseName: "OrderManagementDbTest")
            .Options;
        _context = new OrderManagementDbContext(options);
        var customerRepository = new CustomerRepository(_context);
        _customerService = new CustomerService(customerRepository);
    }

    [Fact]
    public async Task CreateCustomer_ShouldCreateCustomer()
    {
        var customer = new Customer
        {
            Name = "John Doe",
            Email = "john.doe@example.com"
        };

        var createdCustomer = await _customerService.CreateCustomerAsync(customer);

        Assert.NotNull(createdCustomer);
        Assert.Equal(customer.Name, createdCustomer.Name);
    }

    [Fact]
    public async Task GetCustomerOrders_ShouldReturnOrders()
    {
        var customer = new Customer
        {
            Name = "John Doe",
            Email = "john.doe@example.com",
            Orders = new List<Order>
            {
                new Order { OrderDate = DateTime.UtcNow, TotalAmount = 100 }
            }
        };
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();

        var orders = await _customerService.GetCustomerOrdersAsync(customer.CustomerId);

        Assert.NotNull(orders);
        Assert.Single(orders);
    }
}
