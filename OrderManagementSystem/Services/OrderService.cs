using OrderManagementSystem.Models;
using OrderManagementSystem.Repositories.Interfaces;
using OrderManagementSystem.Services.Interfaces;
using OrderManagementSystem.Helpers;

namespace OrderManagementSystem.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly EmailHelper _emailHelper;

        public OrderService(IOrderRepository orderRepository, EmailHelper emailHelper)
        {
            _orderRepository = orderRepository;
            _emailHelper = emailHelper;
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {

            var createdOrder = await _orderRepository.AddAsync(order);

            var invoice = new Invoice
            {
                OrderId = createdOrder.OrderId,
                InvoiceDate = DateTime.UtcNow,
                TotalAmount = createdOrder.TotalAmount
            };


            await _emailHelper.SendEmailAsync(order.Customer.Email, "Order Created", "Your order has been created.");

            return createdOrder;
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _orderRepository.GetByIdAsync(orderId);
        }

        public async Task UpdateOrderStatusAsync(int orderId, string status)
        {
            await _orderRepository.UpdateStatusAsync(orderId, status);
        }
    }
}
