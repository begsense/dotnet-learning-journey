//Console and Convert Basics
/*Console.Write("Input Your name please: ");
string myName = Console.ReadLine();

Console.WriteLine($"User Input was: {myName}");


string myString = "13";
string myString2 = "7";

Console.WriteLine(myString + myString2); //Concatenation


Console.WriteLine("Please enter a number: ");
int firstNumber = int.Parse(Console.ReadLine());
Console.WriteLine("Please enter another number: ");
int secondNumber = int.Parse(Console.ReadLine());

int sum = firstNumber + secondNumber;

Console.WriteLine($"The sum of {firstNumber} and {secondNumber} is {sum}");
*/

//if statements
int age = 30;

if (age > 50)
{
    Console.WriteLine("Age is more then 50");
}
else
{
    Console.WriteLine("Age is 50 or less");
}


int speed = 100;

if (speed < 60)
{
    Console.WriteLine("You are driving below the speed limit");
}
else if (speed >= 60 && speed <= 75)
{
    Console.WriteLine("You are driving within the speed limit");
}
else
{
    Console.WriteLine("You are driving above the speed limit");
}


int age2 = 25;
bool hasLicense = false;

if (age2 > 17 && hasLicense)
{
    Console.WriteLine("You can drive");
}
else if (age2 > 17 && !hasLicense)
{
    Console.WriteLine("You cannot drive, start stading");
}
else if (age2 < 17 && !hasLicense)
{
    Console.WriteLine("You cannot drive, you are too young");
}
else if (age2 < 17 && hasLicense)
{
    Console.WriteLine("Somehow You can drive, because you have a license");
}
else
{
    Console.WriteLine("You cannot drive, you are too young and you don't have a license");
}


decimal balanceOnAccount = 1000;
decimal balanceOnCard = 3000;
decimal price = 2500;

if (balanceOnAccount > price || balanceOnCard > price || balanceOnAccount + balanceOnCard > price)
{
    Console.WriteLine("You can make the purchase");
}
else
{
    Console.WriteLine("You cannot make the purchase");
}