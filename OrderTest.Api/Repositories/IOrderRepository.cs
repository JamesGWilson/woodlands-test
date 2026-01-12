using OrderTest.Api.Models;

namespace OrderTest.Api.Repositories;

public interface IOrderRepository
{
    void Add(Order order);
    Order GetById(int id);
    IEnumerable<Order> GetAll();
}
