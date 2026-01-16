using OrderTest.Api.Interfaces;

namespace OrderTest.Api.Services;


//if this was fully implemented, there would be ean OrderReferenceNumber on the order
//not just an ID, and I would pass the order reference number to this service
//and include it in the email and text messages to the customer

public class EmailNotificationService : INotificationService
{
    public void SendEmail(string to)
    {
        Console.WriteLine($"Sending email to {to}: Order created");
        Console.WriteLine($"Your order has been created");
    }

    public void SendSms(string phoneNumber)
    {
        Console.WriteLine($"Sending sms to {phoneNumber}: Order created");
        Console.WriteLine($"Your Order has been created");
    }
}
