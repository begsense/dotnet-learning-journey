namespace Lecture14.Models;

internal class User
{
    // field
    private string _fullName;
    private decimal balance = 1500;
    private bool isAdmin;

    // property
    public string FullName
    {
        get { return _fullName; }
        set 
        { 
            if (value.Length > 3)
            {
                _fullName = value;
            }
            else
            {
                Console.WriteLine("Full Name must be longer than 3 characters.");
            }
        }
    }

    public decimal Balance
    {
        get 
        {
            Console.WriteLine("Shemoiyvane pin");
            int pin = int.Parse(Console.ReadLine());

            if (pin == 1234)
            {
                return balance;
            }
            else
            {
                Console.WriteLine("Invalid PIN.");
                return 0;
            }
        }
    }

    public bool IsAdmin
    {
        get { return isAdmin; }
    }


    public void Deposit()
    {
        Console.WriteLine("Enter amount to deposit:");
        decimal amount = decimal.Parse(Console.ReadLine());
        if (amount <= 0)
        {
            Console.WriteLine("Deposit amount must be positive.");
        }
        else
        {
            balance += amount;
        }
        Console.WriteLine($"Deposited: {amount}. New balance: {balance}");
    }
}
