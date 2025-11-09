using Lecture17.Models;

#region list of products
List<Product> products = new List<Product> { new Product { ProductName = "ProBook Laptop", Price = 1299.99m, IsAvailable = true, QuantityInStock = 50, Rating = 4.5 }, new Product { ProductName = "Galaxy Smartphone", Price = 899.50m, IsAvailable = true, QuantityInStock = 120, Rating = 4.7 }, new Product { ProductName = "Noise-Canceling Headphones", Price = 249.00m, IsAvailable = true, QuantityInStock = 75, Rating = 4.8 }, new Product { ProductName = "Wireless Optical Mouse", Price = 25.99m, IsAvailable = true, QuantityInStock = 300, Rating = 4.2 }, new Product { ProductName = "Mechanical Keyboard", Price = 119.99m, IsAvailable = false, QuantityInStock = 0, Rating = 4.6 }, new Product { ProductName = "Ergonomic Office Chair", Price = 349.99m, IsAvailable = true, QuantityInStock = 40, Rating = 4.4 }, new Product { ProductName = "Leather-Bound Notebook", Price = 19.99m, IsAvailable = true, QuantityInStock = 500, Rating = 4.9 }, new Product { ProductName = "Gel Pen Set (12-Pack)", Price = 14.50m, IsAvailable = true, QuantityInStock = 1000, Rating = 4.3 }, new Product { ProductName = "Premium Coffee Beans (1kg)", Price = 22.99m, IsAvailable = true, QuantityInStock = 150, Rating = 4.7 }, new Product { ProductName = "Green Tea Assortment", Price = 12.75m, IsAvailable = true, QuantityInStock = 200, Rating = 4.5 }, new Product { ProductName = "Insulated Water Bottle", Price = 30.00m, IsAvailable = true, QuantityInStock = 250, Rating = 4.8 }, new Product { ProductName = "High-Speed Blender", Price = 99.99m, IsAvailable = true, QuantityInStock = 60, Rating = 4.1 }, new Product { ProductName = "4-Slice Toaster", Price = 45.50m, IsAvailable = false, QuantityInStock = 0, Rating = 3.9 }, new Product { ProductName = "Cotton T-Shirt (White)", Price = 18.99m, IsAvailable = true, QuantityInStock = 400, Rating = 4.0 }, new Product { ProductName = "Men's Denim Jeans", Price = 59.99m, IsAvailable = true, QuantityInStock = 180, Rating = 4.2 }, new Product { ProductName = "Running Sneakers", Price = 89.99m, IsAvailable = true, QuantityInStock = 110, Rating = 4.6 }, new Product { ProductName = "Waterproof Rain Jacket", Price = 120.00m, IsAvailable = true, QuantityInStock = 90, Rating = 4.7 }, new Product { ProductName = "The Sci-Fi Novel", Price = 14.99m, IsAvailable = true, QuantityInStock = 300, Rating = 4.8 }, new Product { ProductName = "History of the World", Price = 29.95m, IsAvailable = true, QuantityInStock = 100, Rating = 4.5 }, new Product { ProductName = "RPG Video Game", Price = 59.99m, IsAvailable = true, QuantityInStock = 200, Rating = 4.9 }, new Product { ProductName = "Canvas Backpack", Price = 49.99m, IsAvailable = true, QuantityInStock = 130, Rating = 4.4 }, new Product { ProductName = "27-inch 4K Monitor", Price = 449.99m, IsAvailable = true, QuantityInStock = 30, Rating = 4.7 }, new Product { ProductName = "Cordless Power Drill", Price = 79.00m, IsAvailable = true, QuantityInStock = 80, Rating = 4.6 }, new Product { ProductName = "Smart Watch", Price = 199.99m, IsAvailable = true, QuantityInStock = 100, Rating = 4.3 }, new Product { ProductName = "LED Desk Lamp", Price = 35.00m, IsAvailable = false, QuantityInStock = 0, Rating = 4.1 } };
#endregion

// Example LINQ Queries
while (true)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("1. View By Price");
    Console.WriteLine("2. View Non Available Products");
    Console.WriteLine("3. View All Available Products");
    Console.WriteLine("4. View Products By Stock");
    Console.WriteLine("5. Order By Rating");
    Console.WriteLine("6. Order By Price");
    Console.WriteLine("7. Calculations");
    Console.ResetColor();

    string option = Console.ReadLine();

    if (option == "1")
    {
        Console.Clear();
        PrintTitle("Products By Price");

        Console.WriteLine("Enter Range Start:");
        decimal start = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Enter Range End:");
        decimal end = Convert.ToDecimal(Console.ReadLine());

        List<Product> filteredByPrice = products.Where(p => p.Price >= start && p.Price <= end).ToList();

        foreach (Product product in filteredByPrice)
        {
            Console.WriteLine($"{product.ProductName} - ${product.Price}");
        }

        Reset();
    }
    else if (option == "2")
    {
        Console.Clear();
        PrintTitle("Non Available Products");

        List<Product> nonAvailableProducts = products.Where(p => !p.IsAvailable).ToList();

        foreach (Product product in nonAvailableProducts)
        {
            Console.WriteLine($"{product.ProductName} - ${product.Price}");
        }

        Reset();
    }
    else if (option == "3")
    {
        Console.Clear();
        PrintTitle("All Available Products");

        List<Product> availableProducts = products.Where(p => p.IsAvailable).ToList();

        foreach (Product product in availableProducts)
        {
            Console.WriteLine($"{product.ProductName} - ${product.Price}");
        }

        Reset();
    }
    else if (option == "4")
    {
        Console.Clear();
        PrintTitle("Products By Stock");

        Console.WriteLine("Enter Minimum Stock:");
        int minStock = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Maximum Stock:");
        int maxStock = Convert.ToInt32(Console.ReadLine());

        List<Product> filteredByStock = products.Where(p => p.QuantityInStock >= minStock && p.QuantityInStock <= maxStock).ToList();

        foreach (Product product in filteredByStock)
        {
            Console.WriteLine($"{product.ProductName} - Stock: {product.QuantityInStock}");
        }

        Reset();
    }
    else if (option == "5")
    {
        Console.Clear();
        PrintTitle("Products Ordered By Rating");

        List<Product> orderedByRating = products.OrderByDescending(p => p.Rating).ToList();

        foreach (Product product in orderedByRating)
        {
            Console.WriteLine($"{product.ProductName} - Rating: {product.Rating}");
        }

        Reset();
    }
    else if (option == "6")
    {
        Console.Clear();
        PrintTitle("Products Ordered By Price");

        List<Product> orderedByPrice = products.OrderBy(p => p.Price).ToList();

        foreach (Product product in orderedByPrice)
        {
            Console.WriteLine($"{product.ProductName} - ${product.Price}");
        }

        Reset();
    }
    else if (option == "7")
    {
        Console.Clear();
        PrintTitle("Calculations");

        decimal totalPrice = products.Sum(p => p.Price);
        decimal averagePrice = products.Average(p => p.Price);
        decimal maxPrice = products.Max(p => p.Price);
        decimal minPrice = products.Min(p => p.Price);

        Console.WriteLine($"Total Price of All Products: ${totalPrice}");
        Console.WriteLine($"Average Price of Products: ${averagePrice}");
        Console.WriteLine($"Maximum Price of a Product: ${maxPrice}");
        Console.WriteLine($"Minimum Price of a Product: ${minPrice}");

        // Inventory Value  
        decimal totalAvailableProducts = products.Where(p => p.IsAvailable).Sum(p => p.Price * p.QuantityInStock);

        Reset();
    }
}

void PrintTitle(string title)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"---{title}---");
    Console.ResetColor();
}

void Reset()
{
    Console.ReadKey();
    Console.Clear();
}