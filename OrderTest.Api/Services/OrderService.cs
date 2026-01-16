using OrderTest.Api.DTOs;
using OrderTest.Api.Interfaces;
using OrderTest.Api.Models;

namespace OrderTest.Api.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly INotificationService _emailNotificationService;

    public OrderService(IOrderRepository orderRepository, INotificationService emailNotificationService)
    {
        _orderRepository = orderRepository;
        _emailNotificationService = emailNotificationService;
    }

    public async Task<Order> CreateOrderAsync(CreateOrderDto orderDetails)
    {
        var order = new Order
        {
            Id = Guid.NewGuid(),
            CustomerEmail = orderDetails.CustomerEmail,
            TotalAmount = orderDetails.TotalAmount,
            CreatedAt = DateTime.UtcNow,
            PhoneNumber = orderDetails.PhoneNumber
        };

        await _orderRepository.AddAsync(order);

        _emailNotificationService.SendEmail(order.CustomerEmail);

        if (!string.IsNullOrEmpty(order.PhoneNumber))
        {
            _emailNotificationService.SendSms(order.PhoneNumber);
        }

        return order;
    }

    public async Task<Order?> GetOrderAsync(Guid id)
    {
        return await _orderRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Order>> GetOrdersAsync()
    {
        return await _orderRepository.GetAllAsync();
    }
}
