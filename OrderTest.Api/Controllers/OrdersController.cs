using Microsoft.AspNetCore.Mvc;
using OrderTest.Api.DTOs;
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
    public async Task<IActionResult> Create([FromBody] CreateOrderDto order)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdOrder = await _orderService.CreateOrderAsync(order);

        //will return the Order ID and give you the URL to call the Get with ID in the body of the response
        return CreatedAtAction(
            nameof(Get),
            new { id = createdOrder.Id },
            createdOrder.Id
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var order = await _orderService.GetOrderAsync(id);

        if (order == null)
        {
            return NotFound();
        }

        return Ok(order);
    }
}
