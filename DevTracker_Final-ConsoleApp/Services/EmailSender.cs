using System.Net;
using System.Net.Mail;

using DevTracker_Final_ConsoleApp.Interfaces;

namespace DevTracker_Final_ConsoleApp.Services;

internal class EmailSender : IEmailSender
{
    private string email = Environment.GetEnvironmentVariable("DEVTRACKER_EMAIL");
    private string emailPass = Environment.GetEnvironmentVariable("DEVTRACKER_EMAIL_PASS");

    public void SendEmail(string to, string subject, string body)
    {
        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

        smtpClient.EnableSsl = true;

        smtpClient.Credentials = new NetworkCredential(email, emailPass);

        MailMessage mailMessage = new MailMessage();

        mailMessage.From = new MailAddress(email);

        mailMessage.To.Add(to);

        mailMessage.Subject = subject;

        mailMessage.Body = body;

        smtpClient.Send(mailMessage);
    }
}
