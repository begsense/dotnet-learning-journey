using Lecture10_Classes.Models;
using Lecture10_Classes.Models.Transport;
using Lecture10_Classes.Models.Animal;

User userInfo = new User()
{
    firstName = "Begi",
    lastName = "Kopaliani",
    age = 28,
    isWorking = true
};

Airplane airplane = new Airplane()
{
    brand = "Wizz Air",
    model = "Airbus A320-200",
    capacity = 240,
    price = 200,
    isSold = false,
};

Car car = new Car()
{
    manufacturer = "Zeekr",
    year = 2025,
    fuel = "Electric",
    price = 60000,
    isSold = false,
};

Train train = new Train()
{
    company = "Eurostar",
    numberOfWagons = 25,
    maxSpeed = 360,
    price = 350000,
    isSold = true,
};

Cat cat = new Cat()
{
    breed = "Egyptian",
    age = 1,
    name = "Cookie",
    price = 900,
    isSold = false,
};



Console.WriteLine($"Hi {userInfo.firstName}, your favorite transport is {car.manufacturer} which is {car.price} priced, also sometimes you prefer {train.company} train which is cheeper and its price is {train.price}, you also love cats, your cats name is {cat.name}");