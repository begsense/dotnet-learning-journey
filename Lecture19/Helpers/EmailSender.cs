using System.Net;
using System.Net.Mail;

namespace Lecture19.Helpers;

internal class EmailSender
{
    public void SendEmail(string to, string subject, string body)
    {
        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

        smtpClient.EnableSsl = true;

        smtpClient.Credentials = new NetworkCredential("lashakakashvili114@gmail.com", "gquy");

        MailMessage mail = new MailMessage();

        mail.From = new MailAddress("lashakakashvili114@gmail.com");
        mail.To.Add(to);
        mail.Subject = subject;
        mail.Body = body;

        smtpClient.Send(mail);

        Console.WriteLine("Email sent successfully!");
    }
}
