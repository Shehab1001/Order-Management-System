using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Data;
using OrderManagementSystem.Models;
using OrderManagementSystem.Repositories;
using OrderManagementSystem.Services;
using OrderManagementSystem.Helpers;
using Xunit;

public class OrderServiceTests
{
    private readonly OrderService _orderService;
    private readonly OrderManagementDbContext _context;
    private readonly EmailHelper _emailHelper;

    public OrderServiceTests()
    {
        var options = new DbContextOptionsBuilder<OrderManagementDbContext>()
            .UseInMemoryDatabase(databaseName: "OrderManagementDbTest")
            .Options;
        _context = new OrderManagementDbContext(options);
        _emailHelper = new EmailHelper(new ConfigurationBuilder().AddInMemoryCollection().Build());
        var orderRepository = new OrderRepository(_context);
        _orderService = new OrderService(orderRepository, _emailHelper);
    }

    [Fact]
    public async Task CreateOrder_ShouldCreateOrderAndGenerateInvoice()
    {
        var order = new Order
        {
            CustomerId = 1,
            OrderDate = DateTime.UtcNow,
            TotalAmount = 100,
            OrderItems = new List<OrderItem>
            {
                new OrderItem { ProductId = 1, Quantity = 1, UnitPrice = 100 }
            }
        };

        var createdOrder = await _orderService.CreateOrderAsync(order);

        Assert.NotNull(createdOrder);
        Assert.Equal(order.TotalAmount, createdOrder.TotalAmount);
        Assert.Single(_context.Invoices);
    }
}
