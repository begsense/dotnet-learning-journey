using Assignment7_Encapsulation.Models;

ColorWriteLine("Burger Shop!", ConsoleColor.DarkMagenta);

Console.WriteLine("=============================");

while (true)
{
    ColorWriteLine(message: "Sign in User", ConsoleColor.DarkCyan);

    User user = new User();

    Console.Write("Enter your full name: ");
    user.FullName = Console.ReadLine();

    Console.WriteLine($"Welcome, {user.FullName}!");
    Console.Write("Enter Balance: ");
    decimal depositAmount;

    while (!decimal.TryParse(Console.ReadLine(), out depositAmount) || depositAmount <= 0)
    {
        ColorWriteLine("Invalid amount. Please enter a positive number.", ConsoleColor.Red);
        Console.Write("Enter Balance: ");
    }

    user.Deposit(depositAmount);
    Console.WriteLine($"Your current balance is: {user.Balance:C}");

    Burger cheesburger = new Burger();
    Burger bigmac = new Burger();
    Burger fishy = new Burger();

    cheesburger.Name = "Cheesburger";
    cheesburger.SetPrice(5.99m);
    cheesburger.SetCalories(300);
    bigmac.Name = "Big Mac";
    bigmac.SetPrice(7.49m);
    bigmac.SetCalories(550);
    fishy.Name = "Fishy";
    fishy.SetPrice(6.49m);
    fishy.SetCalories(400);

    ColorWriteLine("Menu:", ConsoleColor.DarkCyan);
    Burger[] menu = { cheesburger, bigmac, fishy };

    Console.WriteLine("=============================");
    Console.WriteLine("Available Burgers:");

    for (int i = 0; i < menu.Length; i++)
    {
        Console.WriteLine($"{i + 1}. {menu[i].Name} - Price: {menu[i].Price:C}, Calories: {menu[i].Calories}");
    }

    Console.Write("Select a burger by entering the corresponding number: ");
    int choice;

    while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > menu.Length)
    {
        ColorWriteLine("Invalid choice. Please select a valid burger number.", ConsoleColor.Red);
        Console.Write("Select a burger by entering the corresponding number: ");
    }

    Burger selectedBurger = menu[choice - 1];

    if (user.Balance >= selectedBurger.Price)
    {
        ColorWriteLine($"You have purchased a {selectedBurger.Name} for {selectedBurger.Price:C}. Enjoy your meal!", ConsoleColor.Green);
    }
    else
    {
        ColorWriteLine("Insufficient balance to make the purchase.", ConsoleColor.Red);
    }

    Console.WriteLine("=============================");
}

void ColorWriteLine(string message, ConsoleColor color)
{
    Console.ForegroundColor = color;
    Console.WriteLine(message);
    Console.ResetColor();
}