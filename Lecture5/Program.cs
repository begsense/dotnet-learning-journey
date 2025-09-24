// Array
/*
// 1st way to create an array
string[] bookNames = new string[2] { "Book1", "Book2" };

// 2nd way to create an array
string[] bookAuthors = new string[] { "Author1", "Author2" };

// 3rd way to create an array
string[] bookPublishers = { "Publisher1", "Publisher2" };

Console.WriteLine(bookNames[0]);
Console.WriteLine(bookAuthors[bookAuthors.Length]);
*/

// research about Array methods and properties
// 1. იპოვეთ ყველაზე დიდი რიცხვი if-else გამოყენებით
int[] numbers = { 45, 89, 23 };

int max = numbers[0];

if (numbers[1] > max)
{
    max = numbers[1];
}

if (numbers[2] > max)
{
    max = numbers[2];
}

Console.WriteLine(max);


// 2.პირველი და ბოლო ელემენტის გაცვლა
string[] words = { "First", "Middle", "Last" };

// შემოგვაქ temp (დროებითი) ცვლადი, რომელშიც შევინახავთ პირველ ელემენტს, ამის შემდეგ არ შეგვეშინდება პირველი ელემენტის დაკარგვის
string temp = words[0];
words[0] = words[words.Length - 1];
words[words.Length - 1] = temp;
Console.WriteLine(words[0]);
Console.WriteLine(words[2]);


// 3. კონკრეტული ელემენტის ძებნა
string[] cities = { "Tbilisi", "Batumi", "Kutaisi", "Rustavi" };

string cityToFind = "Batumi";
bool found = false;

if (Array.IndexOf(cities, cityToFind) >= 0)
{
    found = true;
}

if (found)
{
    Console.WriteLine($"{cityToFind} ნაპოვნია");
}
else
{
    Console.WriteLine($"{cityToFind} ვერ მოიძებნა მასივში");
}


// 4.მასივების გაერთიანება using Array.Copy() და Concat
string[] names1 = { "George", "Nina" };
string[] names2 = { "David", "Mariam" };

// Copy
string[] union = new string[names1.Length + names2.Length];
Array.Copy(names1, union, names1.Length);
Array.Copy(names2, 0, union, names1.Length, names2.Length);
Console.WriteLine(union.Length);

// Concat
string[] union2 = names1.Concat(names2).ToArray();
Console.WriteLine(union2.Length);
// ვერ მივხვდი შინაარსობრივად განსხვავებას. მხოლოდ იმას მივხვდი, რომ Copy თვითონ ერეის მეთოდია და Concat რისი რა არი აზე ვერ მოვდივარ :დ


// 5. მასივის დახარისხება // დაალაგეთ ზრდადობით
int[] scores = { 78, 92, 45, 88, 65 };
Array.Sort(scores);


// 6. ელემენტის არსებობის შემოწმება
double[] prices = { 12.50, 45.99, 23.00, 78.25 };
bool containsPrice = Array.Exists(prices, price => price == 23.00);


// 7.მასივის ზომის შეცვლა
string[] products = { "Bread", "Milk" };
Array.Resize(ref products, 4);
Console.WriteLine(products[3]);
// სიცარიელე შეინახა, სავარაუდოდ null ია და შეგვიძლია შევსება
products[3] = "Eggs";
Console.WriteLine(products[3]);


// 8. ორი მასივის შედარება
int[] array1 = { 1, 2, 3 };
int[] array2 = { 1, 2, 3 };
bool areEqual = array1 == array2; // false, რადგან განსხვავებული რეფერენციები აქვთ memory-ში
bool areEqualContent = array1.SequenceEqual(array2); // true, რადგან შინაარსი ერთნაირია


// 9.მასივის გასუფთავება
string[] data = { "Text1", "Text2", "Text3" };
Array.Clear(data, 0, data.Length); // ყველა ელემენტი გახდება null


// 10. ინდექსების პრაქტიკა და ძებნა
char[] letters = { 'A', 'B', 'C', 'D', 'E' };
Console.WriteLine(letters[0]);
Console.WriteLine(letters[2]);
Console.WriteLine(letters[letters.Length - 1]);
Console.WriteLine(letters[letters.Length - 2]);
int indexOfC = Array.IndexOf(letters, 'C');