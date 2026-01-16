using Microsoft.AspNetCore.Mvc;
using Moq;
using OrderTest.Api.Controllers;
using OrderTest.Api.DTOs;
using OrderTest.Api.Interfaces;
using OrderTest.Api.Services;

namespace OrderTest.UnitTests;

public class OrderServiceTests
{
    [Fact]
    public async Task CreateOrderAsync_Success()
    {
        var mockRepo = new Mock<IOrderRepository>();
        var mockNotificationService = new Mock<INotificationService>();

        var order = new CreateOrderDto
        {
            CustomerEmail = "james.test@gmail.com",
            TotalAmount = 10m,
            PhoneNumber = "12345678901"
        };

        var orderService = new OrderService(mockRepo.Object, mockNotificationService.Object);

        var result = await orderService.CreateOrderAsync(order);

        Assert.NotNull(result);
        Assert.Equal(order.CustomerEmail, result.CustomerEmail);
        Assert.Equal(order.TotalAmount, result.TotalAmount);
        Assert.Equal(order.PhoneNumber, result.PhoneNumber);
        Assert.True(result.CreatedAt <= DateTime.UtcNow);

        mockNotificationService.Verify(m => m.SendEmail(order.CustomerEmail), Times.Once);
        mockNotificationService.Verify(m => m.SendSms(order.PhoneNumber), Times.Once);
    }
}