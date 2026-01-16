using System.ComponentModel.DataAnnotations;

namespace OrderTest.Api.Models;

public class Order
{
    public Guid Id { get; set; }
    public required string CustomerEmail { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? PhoneNumber { get; set; }
}
