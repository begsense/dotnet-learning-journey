// string methods and validations
//1. Length 
string str = "Hello, World!";
Console.WriteLine($"Length of the string: {str.Length}");

//2. ToUpper / ToLower
string test2 = "Hello, World!";
Console.WriteLine($"Uppercase: {test2.ToUpper()}");
Console.WriteLine($"Lowercase: {test2.ToLower()}");

//3. Trim, TrimStart, TrimEnd
string test3 = "   Hello, World!   ";
Console.WriteLine($"Trimmed: '{test3.Trim()}'");
Console.WriteLine($"TrimStart: '{test3.TrimStart()}'");
Console.WriteLine($"TrimEnd: '{test3.TrimEnd()}'");

//validations
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("-------------------------------");
Console.ResetColor();

Console.WriteLine("Shemoiyvanet Saxelmwifo Nomeri");
string carPlate = Console.ReadLine().ToUpper().Trim();

if (carPlate.Length != 7)
{
    Console.WriteLine("Araswori Formatia");
}
else
{
    Console.WriteLine($"Saxelmwifo Nomeri: {carPlate}");
}

//Contains
string something = "   Hello, World!   ";
Console.WriteLine(something.Contains("H"));

if (something.Contains("BadWord"))
{
    Console.WriteLine("Tkveni Komentari Ver Miigheba");
}
else
{
    Console.WriteLine("Tkveni komentari Gamokveknda");
}


string[] products = { "Apple", "Banana", "Orange" };

foreach (string product in products)
{
    if (product.Contains("Appl"))
    {
        Console.WriteLine($"Apple Related Product is: {product}");
    }
    else
    {
        Console.WriteLine($"No Apple Related Product is: {product}");
    }
}

//IndexOf / LastIndexOf
string text = "I love C# programming";
int firstIndex = text.IndexOf("programming");
int lastIndex = text.LastIndexOf("programming");
Console.WriteLine($"First Index: {firstIndex}, Last Index: {lastIndex}");

//Substring
string email = "begsense@gmail.com";
Console.WriteLine(email.Substring(0, 8));
Console.WriteLine(email.IndexOf("@"));
Console.WriteLine(email.Substring(email.IndexOf("@") + 1));

//Replace
Console.WriteLine($"Replace . to _ > result :  {email.Replace(".", "_")}");

//Split
string names = "John,Doe,Jane,Smith";
string[] nameArray = names.Split(',');
foreach (string name in nameArray)
{
    Console.WriteLine(name);
}

//array to string
string[] words = { "Hello", "World", "from", "C#" };
string sentence = string.Join(" ", words);

//EndsWith
string fileName = "document.pdf";
if (fileName.EndsWith(".pdf"))
{
    Console.WriteLine("This is a PDF file.");
}
else
{
    Console.WriteLine("This is not a PDF file.");
}
