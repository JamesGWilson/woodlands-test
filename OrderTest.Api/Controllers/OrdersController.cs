using Microsoft.AspNetCore.Mvc;
using OrderTest.Api.Models;
using OrderTest.Api.Services;

namespace OrderTest.Api.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public IActionResult Create(Order order)
    {
        var createdOrder = _orderService.CreateOrder(order);
        return Ok(createdOrder);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var order = _orderService.GetOrder(id);

        if (order == null)
        {
            return NotFound();
        }

        return Ok(order);
    }
}
