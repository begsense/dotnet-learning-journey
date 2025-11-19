namespace Lecture21.Models;

internal class CasualAccount: BankAccount
{
    public override void Withdraw()
    {
        Console.WriteLine("Withdrawing from a casual account.");
    }
}
