using Assignment6_Planning_Project.Models;

Hero spiderMan = new Hero()
{
    id = 1,
    name = "Spider Man",
    cartoon = "Marvel",
    width = 60,
    height = 120,
    price = 15.99,
    quantity = 1
};

Programs birthDay = new Programs()
{
    id = 1,
    name = "Birthday Party",
    heroes = spiderMan,
    duration = 30,
    price = 49.99,
    quantity = 1
};

Order firstOrder = new Order()
{
    id = 1,
    program = birthDay,
    price = birthDay.price
};

User user = new User()
{
    id = 1,
    fullName = "Begi Kopaliani",
    username = "begsense",
    email = "begsense@gmail.com",
    password = "begsense123",
    orders = firstOrder,
    accountDate = DateTime.Now
};

Console.WriteLine($"User: {user.fullName} ({user.username})");
Console.WriteLine($"Email: {user.email}");
Console.WriteLine($"Account Created On: {user.accountDate}");
Console.WriteLine($"Program: {user.orders.program.name}");
Console.WriteLine($"Hero: {user.orders.program.heroes.name} from {user.orders.program.heroes.cartoon}");
Console.WriteLine($"Program Duration: {user.orders.program.duration} minutes");
Console.WriteLine($"Total Price: ${user.orders.price}");
