namespace Lecture16.Models;

internal class Person
{
    private string _name;

    public Person(string name)
    {
        Name = name;
    }
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
}
