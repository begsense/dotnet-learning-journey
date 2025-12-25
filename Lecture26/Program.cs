using Lecture26.Models;
using Lecture26.Data;

Baza baza = new Baza();

// CREATE

// Add
//Quote quote = new Quote()
//{
//    Title = "Beeeeeeee",
//    Author = "John Jones"
//};

// baza.Quotes.Add(quote);
// baza.SaveChanges();
// Tu list unda davamato mashin baza.Quotes.AddRange(quotes) method

// READ
var allQuotes = baza.Quotes.ToList();

foreach (var quote in allQuotes)
{
    Console.WriteLine($"{quote.Id} | {quote.Author}  |  {quote.Title}");
}

// UPDATE
//Console.WriteLine("Which one you want to edit? id:");
//int id = int.Parse(Console.ReadLine());
//var editQuote = baza.Quotes.FirstOrDefault(x => x.Id == id);

//while (editQuote != null)
//{
//    Console.Clear();
//    Console.WriteLine($"Tkven Airchiet: {editQuote.Author}");

//    Console.WriteLine("What Do you want to edit?");
//    Console.WriteLine("1. Author name");
//    Console.WriteLine("2. Quote");

//    string choice = Console.ReadLine();

//    if (choice == "1")
//    {
//        Console.Clear();
//        Console.WriteLine($"Now Name is: {editQuote.Author}");

//        Console.WriteLine("Enter Name: ");

//        string newName = Console.ReadLine();

//        if (newName != editQuote.Author)
//        {
//            editQuote.Author = newName;

//            baza.Quotes.Update(editQuote);
//            baza.SaveChanges();
//        }
//    }

//    else if (choice == "2")
//    {
//        Console.Clear();
//        Console.WriteLine($"Now Quote is: {editQuote.Title}");

//        Console.WriteLine("Enter Title: ");

//        string newQuote = Console.ReadLine();

//        if (newQuote != editQuote.Title)
//        {
//            editQuote.Title = newQuote;

//            baza.Quotes.Update(editQuote);
//            baza.SaveChanges();
//        }
//    }
//}

// DELETE

Console.WriteLine("Which one you want to delete? id:");
int id = int.Parse(Console.ReadLine());
var deleteQuote = baza.Quotes.FirstOrDefault(x => x.Id == id);

if  (deleteQuote != null)
{
    baza.Quotes.Remove(deleteQuote);
    baza.SaveChanges();
    Console.WriteLine($"deleted quote {deleteQuote.Title}");
}
else
{
    Console.WriteLine("Araswori Id: ");
}