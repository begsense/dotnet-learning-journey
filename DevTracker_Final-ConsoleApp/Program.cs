using DevTracker_Final_ConsoleApp;
using DevTracker_Final_ConsoleApp.Helpers;
using DevTracker_Final_ConsoleApp.Services;

Visualisation visualisation = new Visualisation();

while (true)
{
    visualisation.WriteColored("Welcome To The DevTracker ConsoleApp By B.K", ConsoleColor.White, ConsoleColor.Cyan);
    visualisation.WriteColored("1. Sign In", ConsoleColor.Cyan);
    visualisation.WriteColored("2. Sign Up", ConsoleColor.Cyan);
    visualisation.WriteColored("3. Logout", ConsoleColor.Cyan);

    Console.Write("Choose an option: ");
    string option = Console.ReadLine();

    if (option == "1")
    {
        Console.WriteLine("AuthService.SignIn()");
    }
    else if (option == "2")
    {
        Console.WriteLine("AuthService.SignUn()");
    }
    else if (option == "3")
    {
        visualisation.WriteColored("Thank you for using DevTracker. Goodbye!", ConsoleColor.Green);
        break;
    }
    else
    {
        visualisation.WriteColored("Invalid option. Please try again.", ConsoleColor.Red);
    }
}