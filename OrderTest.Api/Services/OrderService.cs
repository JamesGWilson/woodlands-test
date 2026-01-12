using OrderTest.Api.Models;
using OrderTest.Api.Repositories;

namespace OrderTest.Api.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _repository;
    private readonly EmailNotificationService _notificationService;

    public OrderService(IOrderRepository repository)
    {
        _repository = repository;
        _notificationService = new EmailNotificationService();
    }

    public Order CreateOrder(Order order)
    {
        if (string.IsNullOrEmpty(order.CustomerEmail))
        {
            throw new Exception("Customer email is required");
        }

        order.Id = new Random().Next(1, 1000);
        order.CreatedAt = DateTime.Now;

        _repository.Add(order);

        _notificationService.SendEmail(
            order.CustomerEmail,
            "Order created",
            "Your order has been created"
        );

        return order;
    }

    public Order GetOrder(int id)
    {
        return _repository.GetById(id);
    }

    public IEnumerable<Order> GetOrders()
    {
        return _repository.GetAll();
    }
}
