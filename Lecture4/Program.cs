//Bank Console Imitation

string correctUserName = "begsense";
string correctPin = "1609";

decimal balance = 1500;
decimal limit = 50000;


Console.ForegroundColor = ConsoleColor.White;
Console.BackgroundColor = ConsoleColor.DarkYellow;
Console.WriteLine("Welcome to the Console Bank App!");
Console.ResetColor();

Console.WriteLine("================================");

Console.WriteLine("Please enter your username:");
string userName = Console.ReadLine();

Console.WriteLine("Please enter your PIN:");
string pin = Console.ReadLine();


if (userName == correctUserName && pin == correctPin)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("View Balance (1)");
    Console.WriteLine("Transfer to Accounts (2)");
    Console.WriteLine("Open Deposit (3)");
    Console.WriteLine("Transfer to Mobile (4)");
    Console.WriteLine("Transfer to Communal fees (5)");
    Console.WriteLine("Loans (6)");
    Console.ResetColor();

    Console.WriteLine("Please select an option (1-6):");

    string option = Console.ReadLine();

    if (option == "1")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Your current balance is: {balance} GEL");
        Console.WriteLine($"Your current balance is: {balance / 2.7m} USD");
        Console.WriteLine($"Your current balance is: {balance / 3.1m} EUR");
        Console.ResetColor();
    }
    else if (option == "2")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Enter the PID number to transfer to:");
        string pidNumber = Console.ReadLine();

        if (pidNumber.Length != 11)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid PID number. It must be 11 digits long.");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine("Enter the amount to transfer:");
            decimal transferAmount = decimal.Parse(Console.ReadLine());

            if (transferAmount > balance || transferAmount <= 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Insufficient funds or invalid amount. Transfer failed.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine($"Successfully transferred ${transferAmount} to PID {pidNumber}. New balance: ${balance - transferAmount}");
                Console.ResetColor();
            }
        }
    }
    else if (option == "3")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Enter the amount to deposit:");
        decimal depositAmount = decimal.Parse(Console.ReadLine());

        if (depositAmount <= 0 || depositAmount > limit)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid deposit amount. It must be greater than 0 and less than or equal to the limit.");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine($"Successfully deposited ${depositAmount}. New balance: ${balance + depositAmount}");
            Console.ResetColor();
        }
    }
    else if (option == "4")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Enter the mobile number to transfer to:");
        string mobileNumber = Console.ReadLine();

        if (mobileNumber == null)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid mobile number.");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine("Enter the amount to transfer:");
            decimal mobileTransferAmount = decimal.Parse(Console.ReadLine());
            if (mobileTransferAmount > balance || mobileTransferAmount <= 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Insufficient funds or invalid amount. Transfer failed.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine($"Successfully transferred ${mobileTransferAmount} to mobile number {mobileNumber}. New balance: ${balance - mobileTransferAmount}");
                Console.ResetColor();
            }
        }
    }
    if (option == "5")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Enter the amount to pay for communal fees:");
        decimal communalAmount = decimal.Parse(Console.ReadLine());
        if (communalAmount > balance || communalAmount <= 0)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Insufficient funds or invalid amount. Payment failed.");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine($"Successfully paid ${communalAmount} for communal fees. New balance: ${balance - communalAmount}");
            Console.ResetColor();
        }
    }
    if ( option == "6")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Enter the loan amount:");
        decimal loanAmount = decimal.Parse(Console.ReadLine());
        if (loanAmount <= 0 || loanAmount > limit)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid loan amount. It must be greater than 0 and less than or equal to the limit.");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine($"Successfully granted a loan of ${loanAmount}. New balance: ${balance + loanAmount}");
            Console.ResetColor();
        }
    }
}
else
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.BackgroundColor = ConsoleColor.Red;
    Console.WriteLine("Incorrect username or PIN. Access denied.");
    Console.ResetColor();
}