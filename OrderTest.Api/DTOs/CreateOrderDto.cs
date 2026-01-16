using System.ComponentModel.DataAnnotations;

namespace OrderTest.Api.DTOs;

public class CreateOrderDto
{
    [Required]
    [EmailAddress]
    public required string CustomerEmail { get; set; }

    [Required]
    [Range(0.01, double.MaxValue)]
    public decimal TotalAmount { get; set; }

    [Phone]
    public string? PhoneNumber { get; set; }
}
