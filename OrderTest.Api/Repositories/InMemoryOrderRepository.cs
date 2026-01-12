using OrderTest.Api.Models;

namespace OrderTest.Api.Repositories;

public class InMemoryOrderRepository : IOrderRepository
{
    private static List<Order> _orders = new();

    public void Add(Order order)
    {
        _orders.Add(order);
    }

    public Order GetById(int id)
    {
        return _orders.FirstOrDefault(o => o.Id == id);
    }

    public IEnumerable<Order> GetAll()
    {
        return _orders;
    }
}
