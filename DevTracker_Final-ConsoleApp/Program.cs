using DevTracker_Final_ConsoleApp;
using DevTracker_Final_ConsoleApp.Helpers;
using DevTracker_Final_ConsoleApp.Services;
using DevTracker_Final_ConsoleApp.Menus;
using DevTracker_Final_ConsoleApp.Models;
using DevTracker_Final_ConsoleApp.Enums;

Visualisation visual = new Visualisation();
AuthService authService = new AuthService();
DeveloperMenu developerMenu = new DeveloperMenu();
ManagerMenu managerMenu = new ManagerMenu();


while (true)
{
    visual.WriteColored("Welcome To DevTracker ConsoleApp By B.K", ConsoleColor.Cyan);

    visual.WriteColored("1. Sign In", ConsoleColor.Yellow);
    visual.WriteColored("2. Sign Up", ConsoleColor.Yellow);
    visual.WriteColored("3. Exit", ConsoleColor.Yellow);

    Console.Write("Choose: ");
    string choice = Console.ReadLine();

    if (choice == "1")
    {
        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("Password: ");
        string pass = Console.ReadLine();

        User user = authService.SignIn(email, pass);

        if (user == null)
        {
            visual.WriteColored("Invalid email or password.", ConsoleColor.Red);
            continue;
        }

        visual.WriteColored($"Welcome, {user.UserName}!", ConsoleColor.Green);

        if (user.Role == USER_ROLE.Manager)
            managerMenu.Start(user);
        else
            developerMenu.Start(user);
    }
    else if (choice == "2")
    {
        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("Username: ");
        string username = Console.ReadLine();

        Console.Write("Password: ");
        string pass = Console.ReadLine();

        if (authService.SignUp(email, username, pass))
        {
            visual.WriteColored("Registration successful!", ConsoleColor.Green);
        }
        else
        {
            visual.WriteColored("Sign Up failed.", ConsoleColor.Red);
        }
    }
    else if (choice == "3")
    {
        visual.WriteColored("Goodbye!", ConsoleColor.Green);
        break;
    }
    else
    {
        visual.WriteColored("Invalid option.", ConsoleColor.Red);
    }
}