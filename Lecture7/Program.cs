string[] bookTitles = { "Vepkhistkaosani", "Hamlet", "Data Tutashkhia" };
string[] authors = { "Shota Rustaveli", "William Shakespeare", "Tchabua Amirejibi" };
int[] publishYears = { 1992, 2003, 2010 };
int[] availableCopies = { 3, 1, 2 };
bool[] isGeorgian = { true, false, true };


Console.ForegroundColor = ConsoleColor.DarkBlue;
Console.WriteLine("Welcome to the mini library system!");
Console.ResetColor();
Console.WriteLine("=========================================");

Console.ForegroundColor = ConsoleColor.DarkBlue;
Console.WriteLine("Select an option:");
Console.WriteLine();
Console.ResetColor();

Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("1. Add a new book");
Console.WriteLine("2. View All the books");
Console.WriteLine("3. Search books and withdrawn");
Console.WriteLine("4. Statistics");
Console.WriteLine("5. Return the book");
Console.WriteLine("6. All books of an author");
Console.WriteLine("7. Random book offer");
Console.WriteLine("8. Sort the books by year");
Console.ResetColor();


Console.WriteLine();
Console.ForegroundColor = ConsoleColor.DarkBlue;
Console.Write("Enter your choice (1-8): ");
Console.ResetColor();

string inputString = Console.ReadLine();
Console.WriteLine();

if (int.TryParse(inputString, out int option))
{
    if (option >= 1 && option <= 8)
    {
        if (option == 1)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("Enter a book name: ");
            Console.ResetColor();
            string bookTitle = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("Enter a book author: ");
            Console.ResetColor();
            string bookAuthor = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("Enter a year when book published: ");
            Console.ResetColor();
            string bookYearInput = Console.ReadLine();
            if (!int.TryParse(bookYearInput, out int bookYear))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid year format.");
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("Enter the book available copies: ");
            Console.ResetColor();
            string bookCopiesInput = Console.ReadLine();
            if (!int.TryParse(bookCopiesInput, out int bookCopies))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid number format for available copies.");
                Console.ResetColor();
            }


            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("Is the book Georgian? (yes/no): ");
            Console.ResetColor();
            string isBookGeorgianInput = Console.ReadLine();
            bool isBookGeorgian = isBookGeorgianInput.ToLower() == "yes";


            int newLength = bookTitles.Length + 1;

            Array.Resize(ref bookTitles, newLength);
            Array.Resize(ref authors, newLength);
            Array.Resize(ref publishYears, newLength);
            Array.Resize(ref availableCopies, newLength);
            Array.Resize(ref isGeorgian, newLength);

            bookTitles[newLength - 1] = bookTitle;
            authors[newLength - 1] = bookAuthor;
            publishYears[newLength - 1] = bookYear;
            availableCopies[newLength - 1] = bookCopies;
            isGeorgian[newLength - 1] = isBookGeorgian;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Book added successfully!");
            Console.ResetColor();
        }
        if (option == 2)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("All the books in the library:");
            Console.ResetColor();
            Console.WriteLine("=========================================");

            for (int i = 0; i < bookTitles.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Title: {bookTitles[i]}");
                Console.WriteLine($"Author: {authors[i]}");
                Console.WriteLine($"Published Year: {publishYears[i]}");
                Console.WriteLine($"Available Copies: {availableCopies[i]}");
                Console.WriteLine($"Is Georgian: {(isGeorgian[i] ? "Yes" : "No")}");
                Console.ResetColor();
                Console.WriteLine("-----------------------------------------");
            }
        }
        if (option == 3)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("Enter a book name to search: ");
            Console.ResetColor();

            string searchTitle = Console.ReadLine();
            for (int i = 0; i < bookTitles.Length; i++)
            {
                if (bookTitles[i].Equals(searchTitle, StringComparison.OrdinalIgnoreCase))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Title: {bookTitles[i]}");
                    Console.WriteLine($"Author: {authors[i]}");
                    Console.WriteLine($"Published Year: {publishYears[i]}");
                    Console.WriteLine($"Available Copies: {availableCopies[i]}");
                    Console.WriteLine($"Is Georgian: {(isGeorgian[i] ? "Yes" : "No")}");
                    Console.ResetColor();
                    Console.WriteLine("-----------------------------------------");
                    if (availableCopies[i] > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write("Do you want to withdraw this book? (yes/no): ");
                        Console.ResetColor();
                        string withdrawInput = Console.ReadLine();
                        if (withdrawInput.ToLower() == "yes")
                        {
                            availableCopies[i]--;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Book withdrawn successfully!");
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Sorry, no available copies to withdraw.");
                        Console.ResetColor();
                    }
                }
            }
        }
        if (option == 4)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Library Statistics:");
            Console.ResetColor();
            Console.WriteLine("=========================================");

            int totalBooks = bookTitles.Length;
            int totalAvailableCopies = 0;
            int georgianBooksCount = 0;
            for (int i = 0; i < availableCopies.Length; i++)
            {
                totalAvailableCopies += availableCopies[i];
                if (isGeorgian[i])
                {
                    georgianBooksCount++;
                }
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Total number of books: {totalBooks}");
            Console.WriteLine($"Total available copies: {totalAvailableCopies}");
            Console.WriteLine($"Number of Georgian books: {georgianBooksCount}");
            Console.WriteLine($"Number of Non-Georgian books: {totalBooks - georgianBooksCount}");

            int oldestYear = publishYears[0];
            string oldestBook = bookTitles[0];
            for (int i = 1; i < publishYears.Length; i++)
            {
                if (publishYears[i] < oldestYear)
                {
                    oldestYear = publishYears[i];
                    oldestBook = bookTitles[i];
                }
            }
            Console.WriteLine($"Oldest book: {oldestBook} ({oldestYear})");
            Console.ResetColor();
        }
        else if (option == 5)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("Enter the book name to return: ");
            Console.ResetColor();
            string returnTitle = Console.ReadLine();

            bool bookFound = false;
            for (int i = 0; i < bookTitles.Length; i++)
            {
                if (bookTitles[i].Equals(returnTitle, StringComparison.OrdinalIgnoreCase))
                {
                    availableCopies[i]++;
                    bookFound = true;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Book returned successfully!");
                    Console.ResetColor();
                }
            }
            if (!bookFound)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Book not found in the library.");
                Console.ResetColor();
            }
        }
        else if (option == 6)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("Enter the author's name to view all their books: ");
            Console.ResetColor();

            string authorName = Console.ReadLine();
            bool authorFound = false;
            for (int i = 0; i < authors.Length; i++)
            {
                if (authors[i].Equals(authorName, StringComparison.OrdinalIgnoreCase))
                {
                    authorFound = true;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Title: {bookTitles[i]}");
                    Console.WriteLine($"Published Year: {publishYears[i]}");
                    Console.WriteLine($"Available Copies: {availableCopies[i]}");
                    Console.WriteLine($"Is Georgian: {(isGeorgian[i] ? "Yes" : "No")}");
                    Console.ResetColor();
                    Console.WriteLine("-----------------------------------------");
                }
            }
            if (!authorFound)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No books found for the given author.");
                Console.ResetColor();
            }
        }
        else if (option == 7)
        {
            Console.Clear();
            Random rand = new Random();
            int randomIndex = rand.Next(bookTitles.Length);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Random Book Offer:");
            Console.ResetColor();
            Console.WriteLine("=========================================");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Title: {bookTitles[randomIndex]}");
            Console.WriteLine($"Author: {authors[randomIndex]}");
            Console.WriteLine($"Published Year: {publishYears[randomIndex]}");
            Console.WriteLine($"Available Copies: {availableCopies[randomIndex]}");
            Console.WriteLine($"Is Georgian: {(isGeorgian[randomIndex] ? "Yes" : "No")}");
            Console.ResetColor();
        }
        else if (option == 8)
        {
            Console.Clear();
            Array.Sort(publishYears, bookTitles);
            Array.Sort(publishYears, authors);
            Array.Sort(publishYears, availableCopies);
            Array.Sort(publishYears, isGeorgian);

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Books Sorted by Published Year:");
            Console.ResetColor();
            Console.WriteLine("=========================================");

            for (int i = 0; i < bookTitles.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Title: {bookTitles[i]}");
                Console.WriteLine($"Author: {authors[i]}");
                Console.WriteLine($"Published Year: {publishYears[i]}");
                Console.WriteLine($"Available Copies: {availableCopies[i]}");
                Console.WriteLine($"Is Georgian: {(isGeorgian[i] ? "Yes" : "No")}");
                Console.ResetColor();
                Console.WriteLine("-----------------------------------------");
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please enter a number from 1 up to 8!");
            Console.ResetColor();
        }
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Please enter a number!");
        Console.ResetColor();
    }
}