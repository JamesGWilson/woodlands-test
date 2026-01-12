using OrderTest.Api.Models;

namespace OrderTest.Api.Services;

public interface IOrderService
{
    Order CreateOrder(Order order);
    Order GetOrder(int id);
    IEnumerable<Order> GetOrders();
}
