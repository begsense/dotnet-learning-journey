using Lecture11.Models;
/*
#region monacemebi
Product[] products =
{
    new Product { name = "iPhone 14 Pro", price = 1299.99m, isAvailable = true, quantity = 25, category = "Electronics" },
    new Product { name = "Samsung 55\" Smart TV", price = 899.50m, isAvailable = true, quantity = 12, category = "Electronics" },
    new Product { name = "Asus ROG Gaming Laptop", price = 1899.00m, isAvailable = true, quantity = 8, category = "Electronics" },
    new Product { name = "Sony WH-1000XM5 Headphones", price = 349.99m, isAvailable = true, quantity = 30, category = "Electronics" },
    new Product { name = "Logitech MX Master 3S Mouse", price = 119.99m, isAvailable = true, quantity = 40, category = "Electronics" },

    new Product { name = "Nike Air Force 1", price = 99.99m, isAvailable = true, quantity = 50, category = "Clothing" },
    new Product { name = "Adidas Hoodie", price = 69.99m, isAvailable = true, quantity = 34, category = "Clothing" },
    new Product { name = "Levi's 501 Jeans", price = 89.99m, isAvailable = true, quantity = 20, category = "Clothing" },
    new Product { name = "Puma Running Shorts", price = 39.50m, isAvailable = false, quantity = 0, category = "Clothing" },

    new Product { name = "The Pragmatic Programmer", price = 44.99m, isAvailable = true, quantity = 15, category = "Books" },
    new Product { name = "Clean Code", price = 39.99m, isAvailable = true, quantity = 18, category = "Books" },
    new Product { name = "Design Patterns: Elements of Reusable OO Software", price = 59.95m, isAvailable = false, quantity = 0, category = "Books" },

    new Product { name = "KitchenAid Stand Mixer", price = 499.00m, isAvailable = true, quantity = 6, category = "Home & Kitchen" },
    new Product { name = "Dyson V12 Vacuum Cleaner", price = 749.99m, isAvailable = true, quantity = 10, category = "Home & Kitchen" },
    new Product { name = "IKEA Office Chair", price = 129.00m, isAvailable = true, quantity = 14, category = "Home & Kitchen" },

    new Product { name = "Apple Watch Series 9", price = 399.00m, isAvailable = true, quantity = 22, category = "Wearables" },
    new Product { name = "Fitbit Charge 6", price = 159.99m, isAvailable = true, quantity = 18, category = "Wearables" },

    new Product { name = "Canon EOS R6 Camera", price = 2499.00m, isAvailable = true, quantity = 5, category = "Photography" },
    new Product { name = "GoPro HERO12", price = 499.00m, isAvailable = true, quantity = 9, category = "Photography" },
    new Product { name = "SanDisk 1TB Extreme SSD", price = 149.99m, isAvailable = true, quantity = 35, category = "Accessories" }
};
#endregion

while(true)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("1. View All Products");
    Console.WriteLine("2. View All Available Products");
    Console.WriteLine("3. View Electronics");
    Console.WriteLine("4. View All Products Price (Total)");
    Console.ResetColor();

    string choice = Console.ReadLine();

    if (choice == "1")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("All Products:");
        Console.ResetColor();

        foreach (Product product in products)
        {
            if (product.quantity > 30)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (product.quantity == 0 || product.isAvailable == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (product.quantity >= 10 && product.quantity <= 20)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            Console.WriteLine($"{product.name} - ${product.price} - Available: {product.isAvailable} - Quantity: {product.quantity} - Category: {product.category}");
            Console.ResetColor();
        }

        Console.ReadKey();
        Console.Clear();
    }
    else if (choice == "2")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Available Products:");
        Console.ResetColor();
        foreach (Product product in products)
        {
            if (product.isAvailable)
            {
                if (product.quantity > 30)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (product.quantity == 0 || product.isAvailable == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (product.quantity >= 10 && product.quantity <= 20)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine($"{product.name} - ${product.price} - Available: {product.isAvailable} - Quantity: {product.quantity} - Category: {product.category}");
                Console.ResetColor();
            }
        }
        Console.ReadKey();
        Console.Clear();
    }
    else if (choice == "3")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Electronics Products:");
        Console.ResetColor();
        foreach (Product product in products)
        {
            if (product.category == "Electronics")
            {
                if (product.quantity > 30)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (product.quantity == 0 || product.isAvailable == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (product.quantity >= 10 && product.quantity <= 20)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine($"{product.name} - ${product.price} - Available: {product.isAvailable} - Quantity: {product.quantity} - Category: {product.category}");
                Console.ResetColor();
            }
        }
        Console.ReadKey();
        Console.Clear();
    }
    else if (choice == "4")
    {
        decimal totalPrice = 0;
        foreach (Product product in products)
        {
            totalPrice += product.price * product.quantity;
        }
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Total Price of All Products: ${totalPrice}");
        Console.ResetColor();
        Console.ReadKey();
        Console.Clear();
    }
    else
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid choice. Please try again.");
        Console.ResetColor();
        Console.ReadKey();
        Console.Clear();
    }
}
*/

#region monacemebi
Song[] songs =
{
    new Song { title = "Blinding Lights", artist = "The Weeknd", album = "After Hours", genre = "Pop", releaseYear = 2019 },
    new Song { title = "Watermelon Sugar", artist = "Harry Styles", album = "Fine Line", genre = "Pop", releaseYear = 2019 },
    new Song { title = "Levitating", artist = "Dua Lipa", album = "Future Nostalgia", genre = "Pop", releaseYear = 2020 },
    new Song { title = "Peaches", artist = "Justin Bieber", album = "Justice", genre = "R&B", releaseYear = 2021 },
    new Song { title = "Save Your Tears", artist = "The Weeknd", album = "After Hours", genre = "Pop", releaseYear = 2020 },
    new Song { title = "drivers license", artist = "Olivia Rodrigo", album = "SOUR", genre = "Pop", releaseYear = 2021 },
    new Song { title = "Good 4 U", artist = "Olivia Rodrigo", album = "SOUR", genre = "Pop Rock", releaseYear = 2021 },
    new Song { title = "Deja Vu", artist = "Olivia Rodrigo", album = "SOUR", genre = "Pop", releaseYear = 2021 },
    new Song { title = "Bad Habits", artist = "Ed Sheeran", album = "=", genre = "Pop", releaseYear = 2021 },
    new Song { title = "Shape of You", artist = "Ed Sheeran", album = "÷ (Divide)", genre = "Pop", releaseYear = 2017 },
    new Song { title = "Perfect", artist = "Ed Sheeran", album = "÷ (Divide)", genre = "Pop Ballad", releaseYear = 2017 },
    new Song { title = "Montero (Call Me By Your Name)", artist = "Lil Nas X", album = "Montero", genre = "Hip Hop", releaseYear = 2021 },
    new Song { title = "Lose Yourself", artist = "Eminem", album = "8 Mile Soundtrack", genre = "Hip Hop", releaseYear = 2002 },
    new Song { title = "Smells Like Teen Spirit", artist = "Nirvana", album = "Nevermind", genre = "Grunge", releaseYear = 1991 },
    new Song { title = "Billie Jean", artist = "Michael Jackson", album = "Thriller", genre = "Pop", releaseYear = 1982 },
    new Song { title = "Thriller", artist = "Michael Jackson", album = "Thriller", genre = "Pop", releaseYear = 1982 },
    new Song { title = "Rolling in the Deep", artist = "Adele", album = "21", genre = "Pop", releaseYear = 2010 },
    new Song { title = "Someone You Loved", artist = "Lewis Capaldi", album = "Divinely Uninspired to a Hellish Extent", genre = "Pop", releaseYear = 2019 },
    new Song { title = "Dance Monkey", artist = "Tones and I", album = "The Kids Are Coming", genre = "Pop", releaseYear = 2019 },
    new Song { title = "Old Town Road", artist = "Lil Nas X", album = "7 EP", genre = "Country Rap", releaseYear = 2019 }
};
#endregion

while (true)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("1. View All Songs");
    Console.WriteLine("2. View Pop Songs");
    Console.WriteLine("3. View Songs Released After 2020");
    Console.WriteLine("4. View All Artists");
    Console.WriteLine("5. View Most Popular Artist from the list");
    Console.WriteLine("6. View Total Number of Songs");
    Console.WriteLine("7. View Most Popular Genre");
    Console.WriteLine("8. View Songs by a Specific Artist");
    Console.WriteLine("9. View Songs Released Before 2000");
    Console.WriteLine("10. Exit");

    Console.ResetColor();

    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write("Enter your choice (1-10):");
    Console.ResetColor();
    string choice = Console.ReadLine();

    if (choice == "1")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("All Songs:");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.White;
        foreach (Song song in songs)
        {
            Console.WriteLine($"{song.title} by {song.artist} - Album: {song.album} - Genre: {song.genre} - Released: {song.releaseYear}");
        }
        Console.ResetColor();

        Console.ReadKey();
        Console.Clear();
    }
    else if (choice == "2")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Pop Songs:");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.White;
        foreach (Song song in songs)
        {
            if (song.genre == "Pop")
            {
                Console.WriteLine($"{song.title} by {song.artist} - Album: {song.album} - Genre: {song.genre} - Released: {song.releaseYear}");
            }
        }
        Console.ResetColor();

        Console.ReadKey();
        Console.Clear();
    }
    else if (choice == "3")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Songs Released After 2020:");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.White;
        foreach (Song song in songs)
        {
            if (song.releaseYear > 2020)
            {
                Console.WriteLine($"{song.title} by {song.artist} - Album: {song.album} - Genre: {song.genre} - Released: {song.releaseYear}");
            }
        }
        Console.ResetColor();

        Console.ReadKey();
        Console.Clear();
    }
    else if (choice == "4")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("All Artists:");
        Console.ResetColor();

        string[] artists = new string[songs.Length];
        for (int i = 0; i < songs.Length; i++)
        {
            if (!artists.Contains(songs[i].artist))
            {
                artists[i] = songs[i].artist;
            }
        }

        Console.ForegroundColor = ConsoleColor.White;
        for (int i = 0; i < artists.Length; i++)
        {
            if (artists[i] != null)
            {
                Console.WriteLine(artists[i]);
            }
        }
        Console.ResetColor();

        Console.ReadKey();
        Console.Clear();
    }
    else if (choice == "5")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Most Popular Artist from the list:");
        Console.ResetColor();

        string mostPopularArtist = "";
        int maxCount = 0;

        for (int i = 0; i < songs.Length; i++)
        {
            string currentArtist = songs[i].artist;
            int currentCount = 0;

            for (int j = 0; j < songs.Length; j++)
            {
                if (songs[j].artist == currentArtist)
                {
                    currentCount++;
                }
            }

            if (currentCount > maxCount)
            {
                maxCount = currentCount;
                mostPopularArtist = currentArtist;
            }
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"{mostPopularArtist} ({maxCount} songs)");
        Console.ResetColor();

        Console.ReadKey();
        Console.Clear();
    }
    else if (choice == "6")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Total number of songs: {songs.Length}");
        Console.ResetColor();

        Console.ReadKey();
        Console.Clear();
    }
    else if (choice == "7")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Most Popular Genre:");
        Console.ResetColor();

        string mostPopularGenre = "";
        int maxGenreCount = 0;
        for (int i = 0; i < songs.Length; i++)
        {
            string currentGenre = songs[i].genre;
            int currentCount = 0;

            for (int j = 0; j < songs.Length; j++)
            {
                if (songs[j].genre == currentGenre)
                {
                    currentCount++;
                }
            }

            if (currentCount > maxGenreCount)
            {
                maxGenreCount = currentCount;
                mostPopularGenre = currentGenre;
            }
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"{mostPopularGenre} ({maxGenreCount} songs)");
        Console.ResetColor();

        Console.ReadKey();
        Console.Clear();
    }
    else if (choice == "8")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("Enter artist name: ");
        Console.ResetColor();
        string artistName = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Songs by {artistName}:");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.White;
        bool found = false;
        for (int i = 0; i < songs.Length; i++)
        {
            if (songs[i].artist.ToLower() == artistName.ToLower())
            {
                Console.WriteLine($"{songs[i].title} ({songs[i].releaseYear})");
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No songs found for that artist.");
        }

        Console.ResetColor();

        Console.ReadKey();
        Console.Clear();

    }
    else if (choice == "9")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Songs Released Before 2000:");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.White;
        for (int i = 0; i < songs.Length; i++)
        {
            if (songs[i].releaseYear < 2000)
                Console.WriteLine($"{songs[i].title} by {songs[i].artist} ({songs[i].releaseYear})");
        }

        Console.ResetColor();

        Console.ReadKey();
        Console.Clear();
    }
    else if (choice == "10")
    {
        Console.WriteLine("Exiting...");
        break;
    }
    else
    {
        Console.WriteLine("Bad choice. Try again.");
    }
}