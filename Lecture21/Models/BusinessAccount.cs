namespace Lecture21.Models;

internal class BusinessAccount: BankAccount
{
    public override void Withdraw()
    {
        Console.WriteLine("Withdrawing from a business account.");
    }
}
