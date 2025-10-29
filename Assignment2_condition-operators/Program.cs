// variables
string correctUserName = "begsense";
string correctPassword = "1234";
decimal balance = 3000;
decimal dailyLimit = 10000;
string cardNumber = "4111222233334444";

// exchange rates
decimal usdRate = 2.70m;
decimal eurRate = 3.00m;

// authentication
Console.ForegroundColor = ConsoleColor.White;
Console.BackgroundColor = ConsoleColor.DarkYellow;
Console.WriteLine("Welcome to the Console Bank App!");
Console.ResetColor();

Console.WriteLine("================================");

Console.ForegroundColor = ConsoleColor.White;
Console.BackgroundColor = ConsoleColor.DarkYellow;
Console.WriteLine("Please enter your username:");
Console.ResetColor();
string userName = Console.ReadLine();

Console.ForegroundColor = ConsoleColor.White;
Console.BackgroundColor = ConsoleColor.DarkYellow;
Console.WriteLine("Please enter your PIN:");
Console.ResetColor();
string password = Console.ReadLine();

if (userName == correctUserName && password == correctPassword)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Login successful! Welcome to your account.");
    Console.ResetColor();
    Console.Beep(800, 200);

    Console.ForegroundColor = ConsoleColor.White;
    Console.BackgroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("View Balance (1)");
    Console.WriteLine("Withdraw Cash (2)");
    Console.WriteLine("Transfer to Accounts (3)");
    Console.WriteLine("Transfer to Someone else (4)");
    Console.WriteLine("Transfer to Mobile (5)");
    Console.WriteLine("Payment to Internet (6)");
    Console.WriteLine("Payment to Electricity (7)");
    Console.WriteLine("Payment to Water (8)");
    Console.WriteLine("Payment to Gas (9)");
    Console.WriteLine("Payment to Cleaning (10)");
    Console.WriteLine("Payment to Penalties (11)");
    Console.WriteLine("Open Deposit (12)");
    Console.WriteLine("Loan Calculator (13)");
    Console.WriteLine("Exchange Currencies (14)");
    Console.WriteLine("Info about Card (15)");
    Console.WriteLine("Update the Pincode (16)");
    Console.WriteLine("Transfers History (17)");
    Console.WriteLine("Contacts History (18)");
    Console.WriteLine("Active Promo Code (19)");
    Console.WriteLine("Exit Program (20)");
    Console.ResetColor();

    Console.WriteLine("================================");

    Console.ForegroundColor = ConsoleColor.White;
    Console.BackgroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("Please select an option (1-20):");
    Console.ResetColor();
    string option = Console.ReadLine();

    //view balance
    if (option == "1")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Your current balance is: {balance} GEL");
        Console.WriteLine($"Your current balance is: {balance * usdRate} USD");
        Console.WriteLine($"Your current balance is: {balance * eurRate} EUR");
        Console.ResetColor();
    }
    //cash withdraw
    else if (option == "2")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"Choose the Amount you want to Withdrawn: GEL");
        Console.ResetColor();
        Console.WriteLine("================================");

        if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
        {
            if (amount <= balance && amount <= dailyLimit)
            {
                balance -= amount;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"You have successfully withdrawn {amount} GEL.");
                Console.WriteLine($"Your new balance is: {balance} GEL");
            }
            else if (amount > dailyLimit)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Transaction exceeds daily limit.");
                Console.ResetColor();
                Console.Beep(300, 500);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Insufficient funds.");
                Console.ResetColor();
                Console.Beep(300, 500);
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid amount entered.");
            Console.ResetColor();
            Console.Beep(300, 500);
        }
    }
    //transfer to account
    else if (option == "3")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Enter amount to deposit (GEL):");
        Console.ResetColor();

        if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
        {
            balance += amount;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Successfully deposited {amount:F2} GEL");
            Console.WriteLine($"Your new balance is: {balance:F2} GEL");
            Console.ResetColor();
            Console.Beep(800, 200);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid amount entered.");
            Console.ResetColor();
            Console.Beep(300, 500);
        }
        Console.ResetColor();
    }
    //transfer to someone else with personal id
    else if (option == "4")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Enter the PID number to transfer to:");
        Console.ResetColor();

        string personalID = Console.ReadLine();
        if (personalID.Length == 11 && personalID.All(char.IsDigit))
        {
            Console.WriteLine("Enter the amount to transfer:");
            if (decimal.TryParse(Console.ReadLine(), out decimal transferAmount) && transferAmount > 0)
            {
                if (transferAmount <= balance)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Successfully transferred ${transferAmount} to PID {personalID}. New balance: ${balance - transferAmount}");
                    Console.ResetColor();
                    Console.Beep(800, 200);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Insufficient funds.");
                    Console.ResetColor();
                    Console.Beep(300, 500);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid amount entered.");
                Console.ResetColor();
                Console.Beep(300, 500);
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid amount entered.");
            Console.ResetColor();
            Console.Beep(300, 500);
        }
    }
    //transfer to mobile
    else if (option == "5")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Choose Operator:");
        Console.WriteLine("1 - Magti");
        Console.WriteLine("2 - Silknet");
        Console.WriteLine("3 - Beeline");
        Console.ResetColor();

        int operatorChoice = int.Parse(Console.ReadLine());

        if (operatorChoice > 0 && operatorChoice < 4)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Enter phone number (9 digits, starts with 5):");
            Console.ResetColor();
            string phoneNumber = Console.ReadLine();

            if (phoneNumber.Length == 9 && phoneNumber.StartsWith("5") && phoneNumber.All(char.IsDigit))
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Enter top-up amount (1 - 100 GEL):");
                Console.ResetColor();

                if (decimal.TryParse(Console.ReadLine(), out decimal topUpAmount) && topUpAmount >= 1 && topUpAmount <= 100)
                {
                    if (topUpAmount <= balance)
                    {
                        balance -= topUpAmount;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Successfully topped up {phoneNumber} with {topUpAmount:F2} GEL");
                        Console.WriteLine($"Your new balance is: {balance:F2} GEL");
                        Console.ResetColor();
                        Console.Beep(800, 200);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Insufficient funds.");
                        Console.ResetColor();
                        Console.Beep(300, 500);
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid top-up amount.");
                    Console.ResetColor();
                    Console.Beep(300, 500);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid phone number.");
                Console.ResetColor();
                Console.Beep(300, 500);
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid choice of operators digit.");
            Console.ResetColor();
            Console.Beep(300, 500);
        }
    }
    //internet payment
    else if (option == "6")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Choose Internet Provider:");
        Console.WriteLine("1 - Magti");
        Console.WriteLine("2 - Silknet");
        Console.WriteLine("3 - Skynet");
        Console.ResetColor();
        int provider = int.Parse(Console.ReadLine());

        if (provider > 0 && provider < 4)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Enter subscriber code:");
            Console.ResetColor();
            string subscriberCode = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Enter amount to pay (GEL):");
            Console.ResetColor();

            if (decimal.TryParse(Console.ReadLine(), out decimal internetPayment) && internetPayment > 0)
            {
                if (internetPayment <= balance)
                {
                    balance -= internetPayment;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Successfully paid {internetPayment:F2} GEL for Internet. Subscriber code: {subscriberCode}");
                    Console.WriteLine($"Your new balance is: {balance:F2} GEL");
                    Console.ResetColor();
                    Console.Beep(800, 200);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Insufficient funds.");
                    Console.ResetColor();
                    Console.Beep(300, 500);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid payment amount.");
                Console.ResetColor();
                Console.Beep(300, 500);
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid choice of provider digit.");
            Console.ResetColor();
            Console.Beep(300, 500);
        }
    }
    //electricity payment
    else if (option == "7")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Electricity Bill Payment");
        Console.ResetColor();

        Console.WriteLine("================================");

        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Enter subscriber code (10 digits):");
        Console.ResetColor();
        string subscriberCode = Console.ReadLine();

        if (subscriberCode.Length == 10 && subscriberCode.All(char.IsDigit))
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Enter meter reading (kWh):");
            Console.ResetColor();

            if (decimal.TryParse(Console.ReadLine(), out decimal kWh) && kWh > 0)
            {
                decimal total = kWh * 0.25m;

                if (total <= balance)
                {
                    balance -= total;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Successfully paid {total:F2} GEL for Electricity.");
                    Console.WriteLine($"Your new balance is: {balance:F2} GEL");
                    Console.ResetColor();
                    Console.Beep(800, 200);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Insufficient funds.");
                    Console.ResetColor();
                    Console.Beep(300, 500);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid meter reading.");
                Console.ResetColor();
                Console.Beep(300, 500);
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid subscriber code.");
            Console.ResetColor();
            Console.Beep(300, 500);
        }
    }
    //water payment
    else if (option == "8")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Water Bill Payment");
        Console.ResetColor();

        Console.WriteLine("================================");

        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Enter subscriber code:");
        Console.ResetColor();
        string subscriberCode = Console.ReadLine();

        if (!string.IsNullOrEmpty(subscriberCode))
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Enter consumed cubic meters:");
            Console.ResetColor();

            if (decimal.TryParse(Console.ReadLine(), out decimal cubicMeters) && cubicMeters > 0)
            {
                decimal total = cubicMeters * 0.80m;

                if (total <= balance)
                {
                    balance -= total;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Successfully paid {total:F2} GEL for Water.");
                    Console.WriteLine($"Your new balance is: {balance:F2} GEL");
                    Console.ResetColor();
                    Console.Beep(800, 200);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Insufficient funds.");
                    Console.ResetColor();
                    Console.Beep(300, 500);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid cubic meter value.");
                Console.ResetColor();
                Console.Beep(300, 500);
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid subscriber code.");
            Console.ResetColor();
            Console.Beep(300, 500);
        }
    }
    //gas payment
    else if (option == "9")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Gas Bill Payment");
        Console.ResetColor();

        Console.WriteLine("================================");

        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Enter subscriber code:");
        Console.ResetColor();
        string subscriberCode = Console.ReadLine();

        if (!string.IsNullOrEmpty(subscriberCode))
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Enter consumed kilowatt-hours (kWh):");
            Console.ResetColor();

            if (decimal.TryParse(Console.ReadLine(), out decimal kWh) && kWh > 0)
            {
                decimal total = kWh * 0.40m;

                if (total <= balance)
                {
                    balance -= total;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Successfully paid {total:F2} GEL for Electricity.");
                    Console.WriteLine($"Your new balance is: {balance:F2} GEL");
                    Console.ResetColor();
                    Console.Beep(800, 200);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Insufficient funds.");
                    Console.ResetColor();
                    Console.Beep(300, 500);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid kWh value.");
                Console.ResetColor();
                Console.Beep(300, 500);
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid subscriber code.");
            Console.ResetColor();
            Console.Beep(300, 500);
        }
    }
    //cleaning payment
    else if (option == "10")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Cleaning Service Payment");
        Console.ResetColor();

        Console.WriteLine("================================");

        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Enter number of months to pay:");
        Console.ResetColor();

        if (int.TryParse(Console.ReadLine(), out int months) && months > 0)
        {
            decimal total = months * 5m;

            if (total <= balance)
            {
                balance -= total;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Successfully paid {total:F2} GEL for Cleaning Service ({months} months).");
                Console.WriteLine($"Your new balance is: {balance:F2} GEL");
                Console.ResetColor();
                Console.Beep(800, 200);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Insufficient funds.");
                Console.ResetColor();
                Console.Beep(300, 500);
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid number of months.");
            Console.ResetColor();
            Console.Beep(300, 500);
        }
    }
    //penalties payment
    else if (option == "11")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Penalty Payment");
        Console.ResetColor();

        Console.WriteLine("================================");

        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Choose penalty type:");
        Console.WriteLine("1 - Parking (10 GEL)");
        Console.WriteLine("2 - Speeding (50 GEL)");
        Console.WriteLine("3 - Red Light Violation (100 GEL)");
        Console.ResetColor();

        if (int.TryParse(Console.ReadLine(), out int penaltyChoice) && penaltyChoice >= 1 && penaltyChoice <= 3)
        {
            decimal penaltyAmount = 0;

            if (penaltyChoice == 1)
            {
                penaltyAmount = 10;
            }
            else if (penaltyChoice == 2)
            {
                penaltyAmount = 50;
            }
            else
            {
                penaltyAmount = 100;
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Enter fine receipt number:");
            Console.ResetColor();
            string receiptNumber = Console.ReadLine();

            if (!string.IsNullOrEmpty(receiptNumber))
            {
                if (penaltyAmount <= balance)
                {
                    balance -= penaltyAmount;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Successfully paid {penaltyAmount:F2} GEL fine.");
                    Console.WriteLine($"Receipt number: {receiptNumber}");
                    Console.WriteLine($"Your new balance is: {balance:F2} GEL");
                    Console.ResetColor();
                    Console.Beep(800, 200);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Insufficient funds.");
                    Console.ResetColor();
                    Console.Beep(300, 500);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid receipt number.");
                Console.ResetColor();
                Console.Beep(300, 500);
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid fine type.");
            Console.ResetColor();
            Console.Beep(300, 500);
        }
    }
    //deposit open
    else if (option == "12")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Open Deposit");
        Console.ResetColor();

        Console.WriteLine("================================");

        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Choose term (months):");
        Console.WriteLine("1 - 3 months (8%)");
        Console.WriteLine("2 - 6 months (10%)");
        Console.WriteLine("3 - 9 months (11%)");
        Console.WriteLine("4 - 12 months (12%)");
        Console.ResetColor();

        if (int.TryParse(Console.ReadLine(), out int termChoice) && termChoice >= 1 && termChoice <= 4)
        {
            int months = 0;
            decimal rate = 0;

            if (termChoice == 1)
            {
                months = 3;
                rate = 0.08m;
            }
            else if (termChoice == 2)
            {
                months = 6;
                rate = 0.10m;
            }
            else if (termChoice == 3)
            {
                months = 9;
                rate = 0.11m;
            }
            else
            {
                months = 12;
                rate = 0.12m;
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Enter deposit amount (min 100 GEL):");
            Console.ResetColor();

            if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount) && depositAmount >= 100)
            {
                if (depositAmount <= balance)
                {
                    decimal profit = depositAmount * rate * (months / 12m);
                    balance -= depositAmount;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Deposit of {depositAmount:F2} GEL opened for {months} months.");
                    Console.WriteLine($"Annual rate: {rate * 100}%");
                    Console.WriteLine($"Expected profit after {months} months: {profit:F2} GEL");
                    Console.WriteLine($"Your remaining balance is: {balance:F2} GEL");
                    Console.ResetColor();
                    Console.Beep(800, 200);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Insufficient funds.");
                    Console.ResetColor();
                    Console.Beep(300, 500);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid deposit amount.");
                Console.ResetColor();
                Console.Beep(300, 500);
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid choice of term.");
            Console.ResetColor();
            Console.Beep(300, 500);
        }
    }
    //loan calculator
    else if (option == "13")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Loan Calculator");
        Console.ResetColor();

        Console.WriteLine("================================");

        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Enter loan amount (GEL):");
        Console.ResetColor();

        if (decimal.TryParse(Console.ReadLine(), out decimal loanAmount) && loanAmount > 0)
        {
            Console.WriteLine("Enter loan term (months):");
            if (int.TryParse(Console.ReadLine(), out int months) && months > 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Enter annual interest rate (%):");
                Console.ResetColor();

                if (decimal.TryParse(Console.ReadLine(), out decimal annualRate) && annualRate > 0)
                {
                    decimal monthlyRate = annualRate / 100 / 12;
                    decimal monthlyPayment =
                        (loanAmount * monthlyRate) / (1 - (decimal)Math.Pow(1 + (double)monthlyRate, -months));
                    decimal totalPayment = monthlyPayment * months;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Loan amount: {loanAmount:F2} GEL");
                    Console.WriteLine($"Term: {months} months");
                    Console.WriteLine($"Annual rate: {annualRate:F2}%");
                    Console.WriteLine($"Monthly payment: {monthlyPayment:F2} GEL");
                    Console.WriteLine($"Total payment: {totalPayment:F2} GEL");
                    Console.ResetColor();
                    Console.Beep(800, 200);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid annual rate.");
                    Console.ResetColor();
                    Console.Beep(300, 500);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid loan term.");
                Console.ResetColor();
                Console.Beep(300, 500);
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid loan amount.");
            Console.ResetColor();
            Console.Beep(300, 500);
        }
    }
    //exchanges
    else if (option == "14")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Currency Exchange");
        Console.ResetColor();

        Console.WriteLine("================================");

        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"Your current balance: {balance:F2} GEL");
        Console.WriteLine("Choose currency to exchange to:");
        Console.WriteLine("1 - USD (Rate: 2.70)");
        Console.WriteLine("2 - EUR (Rate: 3.00)");
        Console.ResetColor();

        if (int.TryParse(Console.ReadLine(), out int currencyChoice) && currencyChoice >= 1 && currencyChoice <= 3)
        {
            decimal rate = 0;
            string currency = "";

            if (currencyChoice == 1)
            {
                rate = usdRate;
                currency = "USD";
            }
            else
            {
                rate = eurRate;
                currency = "EUR";
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Enter GEL amount to exchange:");
            Console.ResetColor();

            if (decimal.TryParse(Console.ReadLine(), out decimal gelAmount) && gelAmount > 0)
            {
                if (gelAmount <= balance)
                {
                    decimal exchanged = gelAmount / rate;
                    balance -= gelAmount;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Successfully exchanged {gelAmount:F2} GEL to {exchanged:F2} {currency}");
                    Console.WriteLine($"Your new balance is: {balance:F2} GEL");
                    Console.ResetColor();
                    Console.Beep(800, 200);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Insufficient funds.");
                    Console.ResetColor();
                    Console.Beep(300, 500);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid GEL amount.");
                Console.ResetColor();
                Console.Beep(300, 500);
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid currency choice.");
            Console.ResetColor();
            Console.Beep(300, 500);
        }
    }
    //check cards info
    else if (option == "15")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Card Information");
        Console.ResetColor();

        Console.WriteLine("================================");

        string hiddenCard = $"{cardNumber.Substring(0, 4)}****{cardNumber.Substring(12, 4)}";
        string cardType = "Visa";
        string expiryDate = "12/2027";

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Card Number: {hiddenCard}");
        Console.WriteLine($"Card Type: {cardType}");
        Console.WriteLine($"Expiry Date: {expiryDate}");
        Console.WriteLine($"Daily Limit: {dailyLimit:F2} GEL");
        Console.ResetColor();
        Console.Beep(800, 200);
    }
    //change pincode
    else if (option == "16")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Change PIN Code");
        Console.ResetColor();

        Console.WriteLine("================================");

        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Enter old PIN:");
        Console.ResetColor();
        string oldPIN = Console.ReadLine();

        if (oldPIN == correctPassword)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Enter new PIN (4 digits):");
            Console.ResetColor();
            string newPIN = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Confirm new PIN:");
            Console.ResetColor();
            string confirmPIN = Console.ReadLine();

            if (newPIN.Length == 4 && newPIN.All(char.IsDigit))
            {
                if (newPIN == confirmPIN)
                {
                    correctPassword = newPIN;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("PIN successfully changed.");
                    Console.ResetColor();
                    Console.Beep(800, 200);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("PIN confirmation does not match.");
                    Console.ResetColor();
                    Console.Beep(300, 500);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("New PIN must be 4 digits.");
                Console.ResetColor();
                Console.Beep(300, 500);
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Old PIN is incorrect.");
            Console.ResetColor();
            Console.Beep(300, 500);
        }
    }
    //latest transactions check
    else if (option == "17")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Last 5 Transactions");
        Console.ResetColor();

        Console.WriteLine("================================");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Transfer - 50 GEL - 12:30");
        Console.WriteLine("Deposit - 200 GEL - 11:15");
        Console.WriteLine("Withdraw - 100 GEL - 10:50");
        Console.WriteLine("Internet Payment - 30 GEL - 09:40");
        Console.WriteLine("Mobile Top-up - 20 GEL - 09:00");
        Console.ResetColor();
        Console.Beep(800, 200);
    }
    //contact info
    else if (option == "18")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Contact Information");
        Console.ResetColor();

        Console.WriteLine("================================");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Bank Hotline: 032 244 44 44");
        Console.WriteLine("Email: customerservice@bog.ge");
        Console.WriteLine("Number of Branches: 206");
        Console.WriteLine("Working Hours: 10:00 - 18:00");
        Console.ResetColor();
        Console.Beep(800, 200);
    }
    //promo codes
    else if (option == "19")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Activate Promo Code");
        Console.ResetColor();

        Console.WriteLine("================================");

        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Enter promo code:");
        Console.ResetColor();
        string promoCode = Console.ReadLine();

        if (!string.IsNullOrEmpty(promoCode))
        {
            if (promoCode == "BONUS2025")
            {
                balance += 50m;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Promo code applied! 50 GEL added to your balance.");
                Console.WriteLine($"New balance: {balance:F2} GEL");
            }
            else if (promoCode == "GIFT100")
            {
                balance += 100m;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Promo code applied! 100 GEL added to your balance.");
                Console.WriteLine($"New balance: {balance:F2} GEL");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid promo code.");
            }
            Console.ResetColor();
            Console.Beep(800, 200);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No promo code entered.");
            Console.ResetColor();
            Console.Beep(300, 500);
        }
    }
    //exit simulation
    else if (option == "20")
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Exit Program");
        Console.ResetColor();

        Console.WriteLine("================================");

        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Are you sure you want to exit? (yes/no):");
        Console.ResetColor();
        string exitChoice = Console.ReadLine()?.ToLower();

        if (exitChoice == "yes")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Thank you for using Console Bank App. Goodbye!");
            Console.ResetColor();
            Console.Beep(800, 200);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Returning to main menu...");
            Console.ResetColor();
            Console.Beep(800, 200);
        }
    }
}
else
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.BackgroundColor = ConsoleColor.Red;
    Console.WriteLine("Incorrect username or PIN. Access denied.");
    Console.ResetColor();
    Console.Beep(300, 500);
}