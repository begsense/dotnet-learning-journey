using Lecture19.Models;
using BCrypt;
using Lecture19.Helpers;

List<User> users = new List<User>();

while (true)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("1. Register");
    Console.WriteLine("2. Verify Account");
    Console.WriteLine("3. Login");
    Console.ResetColor();

    string choice = Console.ReadLine();

    if (choice == "1")
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine("=======REGISTER=======");

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("Password: ");
        string password = Console.ReadLine();

        var userExists = users.FirstOrDefault(u => u.Email == email);

        if (userExists == null)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            Random rand = new Random();

            int code = rand.Next(1000, 9999);

            User newUser = new User
            {
                Email = email,
                Password = hashedPassword,
                RegisteredAt = DateTime.Now,
                ActivationCode = code.ToString()
            };

            users.Add(newUser);

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine($"User Registered successfuly! Please Enter to continue");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Something went wrong!");
            Console.ResetColor();
        }

        Console.ReadKey();
        Console.Clear();
    }
    else if (choice == "2")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("=======VERIFY ACCOUNT=======");

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("Activation Code: ");
        string code = Console.ReadLine();

        var user = users.FirstOrDefault(u => u.Email == email && u.ActivationCode == code);

        if (user != null)
        {
            user.IsActive = true;
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("Sending Activation code");
            Console.ResetColor();

            EmailSender emailSender = new EmailSender();

            emailSender.SendEmail(user.Email, "Account Activation", $"Your account has been activated successfully!");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid email or activation code!");
            Console.ResetColor();
        }
        Console.ReadKey();
        Console.Clear();
    }
    else if (choice == "3")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("=======LOGIN=======");

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("Password: ");
        string password = Console.ReadLine();

        var user = users.FirstOrDefault(u => u.Email == email);

        if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("Login successful!");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid credentials or account not activated!");
            Console.ResetColor();
        }
        Console.ReadKey();
        Console.Clear();
    }
}