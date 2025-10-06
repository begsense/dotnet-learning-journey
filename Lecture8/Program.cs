/*string[] bookNames =
{
    "Book1",
    "Book2",
    "Book3"
};

// resolve with for loop
for (int i = 0; i < bookNames.Length; i++)
{
    Console.WriteLine($"Book {i + 1}: {bookNames[i]}");
} 

foreach (string bookName in bookNames)
{
    Console.WriteLine(bookName);
}

// resolve with while loop
string userAnswer = "";
while (userAnswer != "exit")
{
    Console.WriteLine("Type 'exit' to stop the loop.");
    userAnswer = Console.ReadLine();
}

#region arrays
string[] allProducts =
{
    "Gaming PC",
    "Toaster",
    "Iron",
    "Chair",
    "Whiteboard",
    "Mouse"
};

string[] tvProducts =
{
    "Remote",
    "LG 65 inch",
    "Sony 75 inch",
    "Samsung 55 inch"
};

string[] computerProducts =
{
    "Nvidia Geforce 4TX 4090ti",
    "Intel i9 13900k",
    "AMD Ryzen 9 7950X"
};

string[] allConsultants =
{
    "Giorgi",
    "Levani",
    "Aleksandre"
};
#endregion

while (true)
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("1. View All Available Products.");
    Console.WriteLine("2. View All TV Products.");
    Console.WriteLine("3. View All Computers Products.");
    Console.WriteLine("4. View All Consultants.");
    Console.ResetColor();

    Console.WriteLine("================================");

    string choice = Console.ReadLine();

    if (choice == "1")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("All Products");
        Console.ResetColor();

        foreach (string product in allProducts)
        {
            Console.WriteLine($"Available Products: {product}");
        }

        Console.ReadKey();
        Console.Clear();
    }
    else if (choice == "2")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("TV Products");
        Console.ResetColor();

        foreach (string product in tvProducts)
        {
            Console.WriteLine($"Available TV Products: {product}");
        }

        Console.ReadKey();
        Console.Clear();
    }
    else if (choice == "3")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Computer Products");
        Console.ResetColor();

        foreach (string product in computerProducts)
        {
            Console.WriteLine($"Available Computer Products: {product}");
        }

        Console.ReadKey();
        Console.Clear();
    }
    else if (choice == "4")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Consultants");
        Console.ResetColor();

        foreach (string consultant in allConsultants)
        {
            Console.WriteLine($"All Consultants: {consultant}");
        }

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

#region arrays
string[] loanProducts =
{
    "Consumer Loan",
    "Car Loan",
    "Mortgage Loan",
    "Credit Card"
};

decimal[] limitAmount = { 10000, 50000, 200000, 7000 };

int[] loanTermsInMonths = { 48, 60, 120, 36 };

decimal[] interestRates = { 0.17m, 0.21m, 0.09m, 0.36m };
#endregion


while (true)
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("1. View All Loan Products with Details.");
    Console.WriteLine("2. Sum of All Loan (Limits).");
    Console.WriteLine("3. Average Interest Rate of All Loans.");
    Console.WriteLine("4. Highest Interest Rate Loan.");
    Console.WriteLine("5. Lowest Interest Rate Loan.");
    Console.WriteLine("6. Exit.");
    Console.ResetColor();

    Console.WriteLine("================================");

    string choice = Console.ReadLine();

    if (choice == "1")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("All Loan Products with Details");
        Console.ResetColor();

        foreach (string product in loanProducts)
        {
            int index = Array.IndexOf(loanProducts, product);
            Console.WriteLine($"Loan Product: {product}");
            Console.WriteLine($"Limit Amount: {limitAmount[index]}");
            Console.WriteLine($"Loan Term (Months): {loanTermsInMonths[index]}");
            Console.WriteLine($"Interest Rate: {interestRates[index]:P2}");
            Console.WriteLine("======================================");
        }

        Console.ReadKey();
        Console.Clear();
    }
    else if (choice == "2")
    {
        Console.Clear();
        decimal sumOfLimits = 0;

        foreach (decimal limit in limitAmount)
        {
            sumOfLimits += limit;
        }

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Sum of All Loan Limits: {sumOfLimits}");
        Console.ResetColor();
        Console.ReadKey();
        Console.Clear();
    }
    else if (choice == "3")
    {
        Console.Clear();
        decimal sumOfInterestRates = 0;

        foreach (decimal rate in interestRates)
        {
            sumOfInterestRates += rate;
        }

        decimal averageInterestRate = sumOfInterestRates / interestRates.Length;
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Average Interest Rate of All Loans: {averageInterestRate:P2}");
        Console.ResetColor();
        Console.ReadKey();
        Console.Clear();
    }
    else if (choice == "4")
    {
        Console.Clear();
        decimal highestInterestRate = interestRates[0];
        string highestInterestLoan = loanProducts[0];

        foreach (string product in loanProducts)
        {
            int index = Array.IndexOf(loanProducts, product);
            if (interestRates[index] > highestInterestRate)
            {
                highestInterestRate = interestRates[index];
                highestInterestLoan = product;
            }
        }

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Highest Interest Rate Loan: {highestInterestLoan} with {highestInterestRate:P2}");
        Console.ResetColor();
        Console.ReadKey();
        Console.Clear();
    }
    else if (choice == "5")
    {
        Console.Clear();
        decimal lowestInterestRate = interestRates[0];
        string lowestInterestLoan = loanProducts[0];

        foreach (string product in loanProducts)
        {
            int index = Array.IndexOf(loanProducts, product);
            if (interestRates[index] < lowestInterestRate)
            {
                lowestInterestRate = interestRates[index];
                lowestInterestLoan = product;
            }
        }

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Lowest Interest Rate Loan: {lowestInterestLoan} with {lowestInterestRate:P2}");
        Console.ResetColor();
        Console.ReadKey();
        Console.Clear();
    }
    else if (choice == "6")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Exiting the program. Goodbye!");
        Console.ResetColor();
        break;
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