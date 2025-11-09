namespace Lecture18.Models;

internal class User
{
    private string _name;
    private string _city;
    private int _age;

    public User(string name, string city, int age)
    {
        Name = name;
        City = city;
        Age = age;
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public string City
    {
        get { return _city; }
        set { _city = value; }
    }

    public int Age
    {
        get { return _age; }
        set { _age = value; }
    }
}
