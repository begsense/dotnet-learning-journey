namespace Lecture15.Models;

internal class Person
{
    private string _name;
    private int _age;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public int Age
    {
        get { return _age; }
        set { _age = value; }
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {_name}, Age: {_age}");
    }
}
