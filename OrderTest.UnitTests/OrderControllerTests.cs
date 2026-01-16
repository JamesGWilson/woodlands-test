using Microsoft.AspNetCore.Mvc;
using Moq;
using OrderTest.Api.Controllers;
using OrderTest.Api.DTOs;
using OrderTest.Api.Services;

namespace OrderTest.UnitTests;

public class OrderControllerTests
{
    [Fact]
    public async Task CreateOrderAsync_BadRequest()
    {
        var mockService = new Mock<IOrderService>();
        var mockController = new OrdersController(mockService.Object);

        mockController.ModelState.AddModelError("CustomerEmail", "Required");

        var order = new CreateOrderDto
        {
            CustomerEmail = string.Empty,
            TotalAmount = 0
        };

        var result = await mockController.Create(order);

        Assert.IsType<BadRequestObjectResult>(result);
    }
}
