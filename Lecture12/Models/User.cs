namespace Lecture12.Models;

internal class User
{
    public string firstName;
    public string lastName;
    public string userName;
    public string email;
    public string password;
    public int age;
    public decimal balance;

    public void CreateAccount()
    {
        Console.WriteLine("Account Created Successfully!");
        Console.WriteLine($"First Name: {firstName}");
        Console.WriteLine($"Last Name: {lastName}");
        Console.WriteLine($"User Name: {userName}");
        Console.WriteLine($"Email: {email}");
        Console.WriteLine($"Age: {age}");
        Console.WriteLine($"Balance: {balance}");
    }

    public void UpdateBalance(decimal amount)
    {
        balance += amount;
        Console.WriteLine($"Balance Updated Successfully! New Balance: {balance}");
    }

    public void UpdatePassword(string newPassword)
    {
        password = newPassword;
        Console.WriteLine("Password Updated Successfully!");
    }

    public void ChangeUserName(string newUserName)
    {
        userName = newUserName;
        Console.WriteLine($"User Name Changed Successfully! New User Name: {userName}");
    }
}
