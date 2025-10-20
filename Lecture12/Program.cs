/* //Methods (Functions)
//Syntacts

using Lecture12;

void SayHello()
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Hello Dear User");
    Console.ResetColor();
}

SayHello();
SayHello();
SayHello();

void PrintDivider()
{
    Console.BackgroundColor = ConsoleColor.White;
    Console.ForegroundColor = ConsoleColor.Black;
    Console.WriteLine("-------------------------");
    Console.ResetColor();
}

PrintDivider();

void SayHelloToUser(string userName)
{
    Console.WriteLine($"Hello  {userName}");
}

SayHelloToUser("Lasha");
SayHelloToUser("Luka");

void Test1()
{
    Console.WriteLine("Test1");
}

void Test2()
{
    Console.WriteLine("Test2");
}

void Test3()
{
    Console.WriteLine("Test3");
}

void CallAllTests()
{
    Test1();
    Test2();
    Test3();
}

CallAllTests();

string GetFullName(string firstName, string lastName)
{
    return firstName + lastName;
}

string fullName = GetFullName("Begi", "Kopaliani");

Console.WriteLine(fullName);

bool IsOver18(int age)
{
    if (age > 18)
    {
        return true;
    }

    return false;
}

Console.WriteLine(IsOver18(18));

User user = new User()
{
    fullName = "Begi",
    age = 18,
    balance = 0
};

user.DisplayUser();
Console.WriteLine(user.GetBalanceStatus());
*/

using Lecture12.Models;

void TextDecoration()
{
    Console.Clear();
    Console.BackgroundColor = ConsoleColor.DarkBlue;
    Console.ForegroundColor = ConsoleColor.White;
}

void ExitDecoration()
{
    Console.ResetColor();
    Console.WriteLine("******************************");
    Console.ReadKey();
    Console.Clear();
}

void Menu()
{
    TextDecoration();
    Console.WriteLine("Welcome to the Banking System");
    Console.WriteLine("1. Create Account");
    Console.WriteLine("2. Add Funds on Balance");
    Console.WriteLine("3. Withdraw Funds from Balance");
    Console.WriteLine("4. Change Password");
    Console.WriteLine("5. Apply for a Loan");
    Console.WriteLine("6. Exit");
    Console.ResetColor();
}

void Main()
{

    while (true)
    {
        Menu();

        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();

        if (choice == "1")
        {
            
            TextDecoration();
            Console.WriteLine("Enter Your FirstName");
            Console.WriteLine("Enter Your LastName");
            Console.WriteLine("Enter Your UserName");
            Console.WriteLine("Enter Your Email");
            Console.WriteLine("Enter Your Password");
            Console.WriteLine("Enter Your Age");

            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            string userName = Console.ReadLine();
            string email = Console.ReadLine();
            string password = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            decimal balance = 0;
            User newUser = new User()
            {
                firstName = firstName,
                lastName = lastName,
                userName = userName,
                email = email,
                password = password,
                age = age,
                balance = balance
            };
            newUser.CreateAccount();
            ExitDecoration();
        }
        else if (choice == "2")
        {
            TextDecoration();
            Console.WriteLine("Login");
            ExitDecoration();
            // Call Login Function
        }
        else if (choice == "3")
        {
            TextDecoration();
            Console.WriteLine("Exiting...");
            ExitDecoration();
            break;
        }
        else
        {
            TextDecoration();
            Console.WriteLine("Invalid Choice, Please try again.");
            ExitDecoration();
        }
    }
}

Main();