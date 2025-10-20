namespace Lecture12;

internal class User
{
    public string fullName;
    public int age;
    public decimal balance;

    public void DisplayUser()
    {
        Console.WriteLine(fullName);
        Console.WriteLine(age);
        Console.WriteLine(balance);
    }

    public string GetBalanceStatus()
    {
        if (balance == 0)
        {
            return "No Funds";
        }
        else if (balance > 100 && balance < 500)
        {
            return "Between 100 and 500";
        }
        else
        {
            return "Other";
        }
    }
}
