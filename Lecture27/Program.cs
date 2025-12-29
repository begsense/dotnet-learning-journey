using Lecture27.Database;
using Lecture27.Models;
using BCrypt;

Data dataBase = new Data();

while (true)
{
    Console.WriteLine("Welcome to Burgershop");

    Console.WriteLine();

    Console.WriteLine("Choose the option");

    Console.WriteLine("================================");

    Console.WriteLine("1. Login");
    Console.WriteLine("2. Register");

    string choice = Console.ReadLine();

    if (choice == "1")
    {
        Console.Clear();

        Console.WriteLine("Enter UserName");
        string userName = Console.ReadLine();

        Console.WriteLine("Enter Password");
        string password = Console.ReadLine();

        var userExists = dataBase.Users.FirstOrDefault(x => x.UserName == userName);

        if (userExists == null)
        {
            Console.WriteLine("UserName or Password is incorect");
            Console.WriteLine("Enter and try again");
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            var isPasswordCorrect = BCrypt.Net.BCrypt.Verify(password, userExists.Password);

            if (isPasswordCorrect)
            {
                bool isLoggedIn = true;

                while (isLoggedIn)
                {
                    Console.Clear();
                    Console.WriteLine("Welcome");

                    Console.WriteLine("================================");

                    Console.WriteLine("1. Add Burger");
                    Console.WriteLine("2. View Burgers");
                    Console.WriteLine("3. Order Burger");
                    Console.WriteLine("4. View Orders");
                    Console.WriteLine("5. Logout");

                    Console.WriteLine("--------------------------------");
                    Console.Write("Choose an option: ");
                    string option = Console.ReadLine();

                    if (option == "1")
                    {
                        AddBurger();
                    }
                    if (option == "2")
                    {
                        ViewBurgers();
                    }
                    if (option == "3")
                    {
                        OrderBurger();
                    }
                    if (option == "4")
                    {
                        isLoggedIn = false;
                        Console.WriteLine("Logged out successfully.");
                        return;
                    }
                }

                void AddBurger()
                {
                    Console.Clear();
                    Console.WriteLine("=== Add Burger ===");

                    Console.Write("Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Description: ");
                    string description = Console.ReadLine();

                    Console.Write("Price: ");
                    decimal price = decimal.Parse(Console.ReadLine());

                    Console.Write("Quantity: ");
                    double quantity = double.Parse(Console.ReadLine());

                    dataBase.Burgers.Add(new Burger
                    {
                        Name = name,
                        Description = description,
                        Price = price,
                        Quantity = quantity,
                        isActive = true
                    });

                    Console.WriteLine("Burger added successfully!");

                    dataBase.SaveChanges();

                }

                void ViewBurgers()
                {
                    Console.Clear();
                    Console.WriteLine("=== Burger List ===");

                    if (!dataBase.Burgers.Any())
                    {
                        Console.WriteLine("No burgers available.");
                        return;
                    }

                    int index = 1;
                    foreach (var burger in dataBase.Burgers)
                    {
                        Console.WriteLine($"{index}. {burger.Name} - ${burger.Price}");
                        index++;
                    }
                }

                void OrderBurger()
                {
                    Console.Clear();
                    Console.WriteLine("=== Order Burger ===");

                    var activeBurgers = dataBase.Burgers.Where(x => x.isActive && x.Quantity > 0).ToList();

                    if (!activeBurgers.Any())
                    {
                        Console.WriteLine("No burgers available to order.");
                        return;
                    }

                    for (int i = 0; i < activeBurgers.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {activeBurgers[i].Name} - ${activeBurgers[i].Price} (Qty: {activeBurgers[i].Quantity})");
                    }

                    Console.Write("Choose burger number: ");
                    int choice = int.Parse(Console.ReadLine());

                    if (choice < 1 || choice > activeBurgers.Count)
                    {
                        Console.WriteLine("Invalid choice!");
                        return;
                    }

                    Console.Write("Enter quantity: ");
                    double qty = double.Parse(Console.ReadLine());

                    var selectedBurger = activeBurgers[choice - 1];

                    if (qty > selectedBurger.Quantity)
                    {
                        Console.WriteLine("Not enough quantity available.");
                        return;
                    }

                    selectedBurger.Quantity -= qty;

                    Console.WriteLine($"Ordered {qty} x {selectedBurger.Name}");
                    Console.WriteLine($"Total price: ${(decimal)qty * selectedBurger.Price}");
                }
            }
            else
            {
                Console.WriteLine("Username or password is incorrect");
            }
        }
    }
    if (choice == "2")
    {
        Console.Clear();

        Console.WriteLine("Enter UserName");
        string userName = Console.ReadLine();

        Console.WriteLine("Enter Password");
        string password = Console.ReadLine();

        var userExists = dataBase.Users.FirstOrDefault(x => x.UserName == userName);

        if (userExists == null)
        {
            User user = new User()
            {
                UserName = userName,
                Password = BCrypt.Net.BCrypt.HashPassword(password)
            };

            dataBase.Users.Add(user);
            dataBase.SaveChanges();

            Console.WriteLine("User Added");
            Console.Clear();
        }
        else
        {
            Console.WriteLine("Invalid UserName");
        }
    }
}