namespace Lecture16.Models;

internal class User
{
    private string _fullName;
    private int _age;
    private bool _isOnline;

    public User()
    {
        Console.WriteLine("Carieli Constructor");
    }

    public User(string fullName, int age)
    {
        FullName = fullName;
        Age = age;

        Console.WriteLine("Constructor parametrebit");
    }

    public string FullName
    {
        get { return _fullName; }
        set { _fullName = value; }
    }

    public int Age
    {
        get { return _age; }
        set { _age = value; }
    }

    public bool IsOnline
    {
        get { return _isOnline; }
    }
}
