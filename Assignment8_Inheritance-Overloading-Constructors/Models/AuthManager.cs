namespace Assignment8_Inheritance_Overloading_Constructors.Models;

internal class AuthManager
{
    public bool Login(string username, string password)
    {
        if (username == "admin" && password == "pass123")
        {
            return true;
        }
        return false;
    }

    public bool Login(string token)
    {
        if (token.Length == 10)
        {
            return true;
        }
        return false;
    }

    public bool Login(int pinCode)
    {
        if (pinCode > 999 && pinCode < 10000)
        {
            return true;
        }
        return false;
    }
}
