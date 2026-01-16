using OrderTest.Api.Interfaces;
using OrderTest.Api.Models;

namespace OrderTest.Api.Repositories;

public class OrderRepository : IOrderRepository
{
    private static List<Order> _orders = new();
    private readonly object _lock = new();

    public Task<Order> AddAsync(Order order)
    {
        lock (_lock)
        {
            _orders.Add(order);
        }

        return Task.FromResult(order);
    }

    public Task<Order?> GetByIdAsync(Guid id)
    {
        Order? order = null;

        lock (_lock)
        {
            order = _orders.FirstOrDefault(o => o.Id == id);
        }

        return Task.FromResult(order);
    }

    public Task<IEnumerable<Order>> GetAllAsync()
    {
        IEnumerable<Order> orderList;

        lock (_lock)
        {
            orderList = _orders.ToList();
        }

        return Task.FromResult(orderList);
    }
}
