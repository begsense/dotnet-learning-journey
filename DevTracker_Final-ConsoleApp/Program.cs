using DevTracker_Final_ConsoleApp;
using DevTracker_Final_ConsoleApp.Helpers;
using DevTracker_Final_ConsoleApp.Services;
using DevTracker_Final_ConsoleApp.Menus;
using DevTracker_Final_ConsoleApp.Models;
using DevTracker_Final_ConsoleApp.Enums;
using DevTracker_Final_ConsoleApp.FileLogging;

Visualisation visual = new Visualisation();
AuthService authService = new AuthService();
DeveloperMenu developerMenu = new DeveloperMenu();
ManagerMenu managerMenu = new ManagerMenu();
Validator validator = new Validator();
Logger logger = new Logger();


while (true)
{
    visual.WriteColored("Welcome To DevTracker ConsoleApp By B.K", ConsoleColor.White, ConsoleColor.DarkCyan);

    visual.WriteColored("1. Sign In", ConsoleColor.DarkCyan);
    visual.WriteColored("2. Sign Up", ConsoleColor.DarkCyan);
    visual.WriteColored("3. Exit", ConsoleColor.DarkCyan);

    Console.WriteLine();

    visual.WriteColored("Choose: ", ConsoleColor.White, line: false);
    string choice = Console.ReadLine();

    if (choice == "1")
    {
        visual.WriteColored("Email: ", ConsoleColor.White, line: false);
        string email = Console.ReadLine();

        visual.WriteColored("Password: ", ConsoleColor.White, line: false);
        string pass = Console.ReadLine();

        User user = authService.SignIn(email, pass);

        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(pass) || user == null)
        {
            Console.Beep(300, 500);
            visual.WriteColored("Something went wrong, try again [Press any key].", ConsoleColor.Red);
            visual.ClearOnClick();
            continue;
        }

        Console.Clear();
        Console.Beep(800, 200);

        visual.WriteColored("Sign In successfully!", ConsoleColor.Green);

        visual.WriteColored("==============================", ConsoleColor.DarkMagenta);

        if (user.Role == USER_ROLE.Manager)
        {
            managerMenu.Start(user);
            logger.Log($"{user.UserName} Sign In, Email: {user.Email}, ID: {user.Id}, Role: {user.Role}");
        }
        else
        {
            developerMenu.Start(user);
            logger.Log($"{user.UserName} Sign In, Email: {user.Email}, ID: {user.Id}, Role: {user.Role}");
        }
    }
    else if (choice == "2")
    {
        visual.WriteColored("Email: ", ConsoleColor.White, line: false);
        string email = Console.ReadLine();

        visual.WriteColored("Username: ", ConsoleColor.White, line: false);
        string username = Console.ReadLine();

        visual.WriteColored("Password: ", ConsoleColor.White, line: false);
        string pass = Console.ReadLine();

        if (validator.ValidateSignUp(email, username, pass, out string error))
        {
            if (authService.SignUp(email, username, pass))
            {
                Console.Clear();
                Console.Beep(800, 200);

                visual.WriteColored("Registration successfully!", ConsoleColor.Green);

                visual.WriteColored("==============================", ConsoleColor.DarkMagenta);

                User user = authService.SignIn(email, pass);

                if (user.Role == USER_ROLE.Manager)
                {
                    managerMenu.Start(user);
                    logger.Log($"{user.UserName} Sign Up, Email: {user.Email}, ID: {user.Id}, Role: {user.Role}");
                }
                else
                {
                    developerMenu.Start(user);
                    logger.Log($"{user.UserName} Sign Up, Email: {user.Email}, ID: {user.Id}, Role: {user.Role}");
                }
            }
        }
        else
        {
            Console.Beep(300, 500);
            visual.WriteColored($"{error} try again [Press any key].", ConsoleColor.Red);
            visual.ClearOnClick();
        }
    }
    else if (choice == "3")
    {
        Console.Beep(800, 200);
        visual.WriteColored("Goodbye!", ConsoleColor.Green);
        break;
    }
    else
    {
        Console.Beep(300, 500);
        visual.WriteColored("Something went wrong, try again [Press any key].", ConsoleColor.Red);
        visual.ClearOnClick();
    }
}