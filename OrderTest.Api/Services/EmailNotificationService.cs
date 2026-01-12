namespace OrderTest.Api.Services;

public class EmailNotificationService : INotificationService
{
    public void SendEmail(string to, string subject, string body)
    {
        Console.WriteLine($"Sending email to {to}: {subject}");
    }

    public void SendSms(string phoneNumber, string message)
    {
        throw new NotImplementedException();
    }
}
