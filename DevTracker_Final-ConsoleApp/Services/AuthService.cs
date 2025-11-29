using DevTracker_Final_ConsoleApp.Data;
using DevTracker_Final_ConsoleApp.Models;
using DevTracker_Final_ConsoleApp.Enums;
using DevTracker_Final_ConsoleApp.Interfaces;

namespace DevTracker_Final_ConsoleApp.Services;

internal class AuthService : IAuthService
{
    private readonly UserRepository userRepository = new UserRepository();
    private readonly EmailSender emailSender = new EmailSender();
    private readonly PasswordService passwordService = new PasswordService();

    public User SignIn(string email, string password)
    {
        var users = userRepository.Load();

        return users.FirstOrDefault(u =>
            u.Email.Equals(email, StringComparison.OrdinalIgnoreCase) &&
            passwordService.Verify(password, u.Password)
        );
    }

    public bool SignUp(string email, string userName, string password)
    {
        var users = userRepository.Load();

        if (users.Any(x => x.Email.Equals(email, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine("Something Went Wrong");
            return false;
        }

        int verificationCode = new Random().Next(1000, 9999);

        emailSender.SendEmail(email, "DevTracker Sent you Verification Code", $"\r\n<!doctype html>\r\n<html lang=\"en\">\r\n<head>\r\n  <meta charset=\"utf-8\">\r\n  <meta name=\"viewport\" content=\"width=device-width\">\r\n  <title>Verification Code</title>\r\n</head>\r\n<body style=\"margin:0;padding:0;background:#f4f6f8;font-family:Inter, -apple-system, 'Segoe UI', Roboto, 'Helvetica Neue', Arial, sans-serif;\">\r\n  <center style=\"width:100%; background:#f4f6f8; padding:30px 0;\">\r\n    <table width=\"600\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" style=\"background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 6px 18px rgba(11,22,39,0.08);\">\r\n      <tr>\r\n        <td style=\"padding:28px 32px 18px;\">\r\n          <!-- Header -->\r\n          <table width=\"100%\" role=\"presentation\">\r\n            <tr>\r\n              <td style=\"vertical-align:middle;\">\r\n                <h1 style=\"margin:0;font-size:20px;color:#0b1a2b;\">DevTracker</h1>\r\n                <p style=\"margin:6px 0 0;font-size:13px;color:#65748b;\">DevTracker App sent you a verification code</p>\r\n              </td>\r\n              <td style=\"text-align:right;vertical-align:middle;\">\r\n                <!-- Optional small logo -->\r\n                <div style=\"width:44px;height:44px;border-radius:8px;background:#eef2ff;display:inline-flex;align-items:center;justify-content:center;font-weight:700;color:#3b82f6;\">DT</div>\r\n              </td>\r\n            </tr>\r\n          </table>\r\n        </td>\r\n      </tr>\r\n\r\n      <tr>\r\n        <td style=\"padding:18px 32px;\">\r\n          <p style=\"margin:0 0 14px;color:#253243;font-size:15px;line-height:1.4;\">\r\n            Hi there — use the code below to complete your sign in. This code will expire in <strong>10 minutes</strong>.\r\n          </p>\r\n\r\n          <!-- Code box -->\r\n          <div style=\"margin:18px 0;padding:18px;border-radius:8px;background:#f8fafc;border:1px dashed #e6eef7;text-align:center;\">\r\n            <p style=\"margin:0;font-size:28px;letter-spacing:4px;font-weight:700;color:#0b1a2b;\">\r\n              {verificationCode}\r\n            </p>\r\n          </div>\r\n\r\n          <p style=\"margin:0 0 10px;color:#556677;font-size:13px;\">\r\n            Didn’t request this? You can safely ignore this email.\r\n          </p>\r\n\r\n          <hr style=\"border:none;border-top:1px solid #eef3f7;margin:20px 0;\">\r\n\r\n          <p style=\"margin:0;font-size:12px;color:#94a3b8;\">\r\n            Need help? Contact <a href=\"mailto:begsense@gmail.com\" style=\"color:#3b82f6;text-decoration:none;\">begsense@gmail.com</a>\r\n          </p>\r\n        </td>\r\n      </tr>\r\n\r\n      <tr>\r\n        <td style=\"padding:14px 32px 24px;background:#fbfdff;text-align:center;font-size:12px;color:#9aa9bb;\">\r\n          © <span id=\"year\">2025</span> DevTracker — All rights reserved.\r\n        </td>\r\n      </tr>\r\n    </table>\r\n\r\n    <!-- plain text fallback for email clients that strip HTML -->\r\n    <div style=\"width:600px;max-width:100%;margin-top:12px;color:#8899aa;font-size:12px;\">\r\n      If you can't see the message, your code is: {verificationCode}\r\n    </div>\r\n  </center>\r\n</body>\r\n</html>\r\n");

        Console.WriteLine($"Verification code sent, please check email");
        Console.Write("Enter verification code: ");
        string inputCode = Console.ReadLine()?.Trim() ?? "";

        if (inputCode != verificationCode.ToString())
        {
            Console.WriteLine("Something went wrong, please try again.");
            return false;
        }

        var newUser = new User
        {
            Id = users.Count == 0 ? 1 : users.Max(u => u.Id) + 1,
            Email = email,
            UserName = userName,
            Password = passwordService.Hash(password),
            Role = USER_ROLE.Developer
        };

        users.Add(newUser);

        userRepository.Save(users);

        Console.WriteLine("You Registered succesfully!");

        return true;
    }
}
