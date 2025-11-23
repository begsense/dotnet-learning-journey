namespace DevTracker_Final_ConsoleApp.Interfaces;

internal interface IEmailSender
{
    void SendEmail(string to, string subject, string body);
}
