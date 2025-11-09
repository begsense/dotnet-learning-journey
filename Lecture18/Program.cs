using Lecture18.Models;

List<User> users = new List<User>
{
    new User("Alice", "New York", 30),
    new User("Bob", "Los Angeles", 25),
    new User("Charlie", "Chicago", 35),
    new User("Diana", "Houston", 28)
};

//. Where : Filter users
var usersStartedWithA = users.Where(u => u.Name.StartsWith("A")).ToList();
var usersOlderThan28 = users.Where(u => u.Age > 28).ToList();

Console.WriteLine("-------------------------");
foreach (var user in usersStartedWithA)
{
    Console.WriteLine($"{user.Name} from {user.City}, Age: {user.Age}");
}

Console.WriteLine("-------------------------");
foreach (var user in usersOlderThan28)
{
    Console.WriteLine($"{user.Name} from {user.City}, Age: {user.Age}");
}

//. Select : Project users to anonymous type
var onlyNames = users.Select(u => u.Name).ToList();
var onlyAgesPlus150 = users.Select(u => u.Age + 150).ToList();
var newAnonymousUsers = users.Select(u => new { u.Name, u.City }).ToList();

Console.WriteLine("-------------------------");
foreach (var name in onlyNames)
{
    Console.WriteLine($"Name: {name}");
}

Console.WriteLine("-------------------------");
foreach (var age in onlyAgesPlus150)
{
    Console.WriteLine($"Age + 150: {age}");
}

Console.WriteLine("-------------------------");
foreach (var anonUser in newAnonymousUsers)
{
    Console.WriteLine($"Name: {anonUser.Name}, City: {anonUser.City}");
}

//. OrderBy : Sort users
var orderedUsers = users.OrderBy(u => u.Name).ThenBy(u => u.Age).ToList();

Console.WriteLine("-------------------------");
foreach (var user in orderedUsers)
{
    Console.WriteLine($"Name: {user.Name}, Age: {user.Age}");
}

//. GroupBy : Group users by city
var groupedUsers = users.GroupBy(u => u.City).ToList();

Console.WriteLine("-------------------------");
foreach (var group in groupedUsers)
{
    Console.WriteLine($"City: {group.Key}");
    foreach (var user in group)
    {
        Console.WriteLine($" - {user.Name}, Age: {user.Age}");
    }
}

//. first , firstOrDefault, single, singleOrDefault
var firstUser = users.First();
var firstUserFromLA = users.FirstOrDefault(u => u.City == "Los Angeles");
var lastUser = users.Last();
var lastUserFromNY = users.LastOrDefault(u => u.City == "New York");

Console.WriteLine("-------------------------");
Console.WriteLine($"First User: {firstUser.Name}");
if (firstUserFromLA != null)
{
    Console.WriteLine($"First User from LA: {firstUserFromLA.Name}");
}
else
{
    Console.WriteLine("No user found from LA");
}

Console.WriteLine($"Last User: {lastUser.Name}");
if (lastUserFromNY != null)
{
    Console.WriteLine($"Last User from NY: {lastUserFromNY.Name}");
}
else
{
    Console.WriteLine("No user found from NY");
}

// Any , All
var anyUserFromChicago = users.Any(u => u.City == "Chicago");
var allUsersAbove20 = users.All(u => u.Age > 20);
Console.WriteLine("-------------------------");
Console.WriteLine($"Any user from Chicago: {anyUserFromChicago}");
Console.WriteLine($"All users above 20: {allUsersAbove20}");

// Distinct
var allCities = users.Select(u => u.City).Distinct().ToList();
Console.WriteLine("-------------------------");
Console.WriteLine("Distinct Cities:");
foreach (var city in allCities)
{
    Console.WriteLine(city);
}


List<Product> products = new List<Product>
{
    new Product("Laptop", "Electronics", 1500m, 10),
    new Product("Smartphone", "Electronics", 800m, 0),
    new Product("Headphones", "Electronics", 150m, 25),
    new Product("Refrigerator", "Appliances", 1200m, 5),
    new Product("Microwave", "Appliances", 300m, 0),
    new Product("Blender", "Appliances", 100m, 15),
    new Product("Sofa", "Furniture", 700m, 2),
    new Product("Dining Table", "Furniture", 900m, 0),
    new Product("Chair", "Furniture", 120m, 30),
    new Product("T-Shirt", "Clothing", 20m, 50),
    new Product("Jeans", "Clothing", 60m, 0),
    new Product("Jacket", "Clothing", 150m, 10)
};


Console.WriteLine("-------------------------");
Console.WriteLine("Products - Category: Electronics:");

var electronicsProducts = products.Where(p => p.Category == "Electronics").ToList();

foreach (var product in electronicsProducts)
{
    Console.WriteLine($"{product.Name} - Price: {product.Price}, Stock: {product.StockQuantity}");
}


Console.WriteLine("-------------------------");
Console.WriteLine("Products - Price > 500 and Is available:");

var over500AvailableProducts = products.Where(p => p.Price > 500 && p.StockQuantity > 0).ToList();

foreach (var product in over500AvailableProducts)
{
    Console.WriteLine($"{product.Name} - Price: {product.Price}, Stock: {product.StockQuantity}");
}


Console.WriteLine("-------------------------");
Console.WriteLine("Names of Products - Category: Books:");

var bookProductNames = products.Where(p => p.Category == "Books").Select(p => p.Name).ToList();

foreach (var name in bookProductNames)
{
    Console.WriteLine(name);
}

Console.WriteLine("-------------------------");
Console.WriteLine("Products Names With Price / 2:");

var productNamesWithHalfPrice = products.Select(p => new { p.Name, HalfPrice = p.Price / 2 }).ToList();

foreach (var item in productNamesWithHalfPrice)
{
    Console.WriteLine($"{item.Name} - Half Price: {item.HalfPrice}");
}


Console.WriteLine("-------------------------");
var allProductsAbove10 = products.All(p => p.Price > 10);
Console.WriteLine($"Is All products above 10: {allProductsAbove10}");


Console.WriteLine("-------------------------");
var anyOutOfStockProduct = products.Any(p => p.StockQuantity == 0);
Console.WriteLine($"Is Any product out of stock: {anyOutOfStockProduct}");


Console.WriteLine("-------------------------");
Console.WriteLine("Products Ordered By Price:");
var productsOrderedByPrice = products.OrderBy(p => p.Price).ToList();
foreach (var product in productsOrderedByPrice)
{
    Console.WriteLine($"{product.Name} - Price: {product.Price}");
}


Console.WriteLine("-------------------------");
Console.WriteLine("Products Ordered By Category Then By Price Desc:");

var productsOrderedByCategoryThenDesc = products.OrderBy(p => p.Category).ThenByDescending(p => p.Price).ToList();

foreach (var product in productsOrderedByCategoryThenDesc)
{
    Console.WriteLine($"{product.Category} - {product.Name} - Price: {product.Price}");
}


Console.WriteLine("-------------------------");
Console.WriteLine("Products Grouped By Category - Clothing:");

var firstClothingProduct = products.First(p => p.Category == "Clothing");

Console.WriteLine($"First Clothing Product: {firstClothingProduct.Name} - Price: {firstClothingProduct.Price}");


Console.WriteLine("-------------------------");
Console.WriteLine("Products Grouped By Category - Toys. (USING FirstOrDefault):");

var furnitureProduct = products.FirstOrDefault(p => p.Category == "Furniture");

if (furnitureProduct == null)
{
    Console.WriteLine("No Product in Furniture category");
}
else
{
    Console.WriteLine($"Furniture First Product: {furnitureProduct.Name} - Price: {furnitureProduct.Price}");
}


Console.WriteLine("-------------------------");
Console.WriteLine("Products Grouped By Category (with names), also count group and calculate average price of group products:");

var groupedProducts = products.GroupBy(p => p.Category);

foreach (var group in groupedProducts)
{
    Console.WriteLine($"Category: {group.Key} - Count: {group.Count()}");

    foreach (var product in group)
    {
        Console.WriteLine($"   - {product.Name}");
    }

    var averagePrice = group.Average(p => p.Price);

    Console.WriteLine($"   - Average Price: {averagePrice}");
}

