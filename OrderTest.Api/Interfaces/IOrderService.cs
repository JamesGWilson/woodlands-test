using OrderTest.Api.DTOs;
using OrderTest.Api.Models;

namespace OrderTest.Api.Services;

public interface IOrderService
{
    Task<Order> CreateOrderAsync(CreateOrderDto order);
    Task<Order?> GetOrderAsync(Guid id);
    Task<IEnumerable<Order>> GetOrdersAsync();
}
