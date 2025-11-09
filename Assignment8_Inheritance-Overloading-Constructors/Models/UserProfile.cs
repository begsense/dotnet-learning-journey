namespace Assignment8_Inheritance_Overloading_Constructors.Models;

internal class UserProfile
{
    private string _username;
    private string _email;
    public string Username
    {
        get { return _username; }
        set { _username = value; }
    }
    public string Email
    {
        get { return _email; }
        set { _email = value; }
    }

    public UserProfile(string username, string email)
    {
        Username = username;
        Email = email;
    }

    public UserProfile(UserProfile other)
    {
        Username = other.Username;
        Email = other.Email;
    }
}
