namespace Lecture21.Models;

public abstract class BankAccount
{
    public decimal Balance { get; set; } = 0;

    public void Deposit(decimal amount)
    {
        Balance += amount;
        Console.WriteLine($"Deposited {amount:C}. New balance is {Balance:C}.");
    }

    public abstract void Withdraw();
}
