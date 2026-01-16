namespace OrderTest.Api.Interfaces;

public interface INotificationService
{
    void SendEmail(string to);
    void SendSms(string phoneNumber);
}
