namespace Assignment8_Inheritance_Overloading_Constructors.Models;

internal class Post
{
    private string _title;

    public string Title
    {
        get { return _title; }
        set { _title = value; }
    }

    public virtual void Display()
    {
        Console.WriteLine($"Post: {Title}");
    }
}
