namespace OrderTest.Api.Services;

public interface INotificationService
{
    void SendEmail(string to, string subject, string body);
    void SendSms(string phoneNumber, string message);
}
