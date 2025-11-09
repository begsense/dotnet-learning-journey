namespace Assignment8_Inheritance_Overloading_Constructors.Models;

internal class BlogPost : Post
{
    private string _author;
    public string Author
    {
        get { return _author; }
        set { _author = value; }
    }
    public BlogPost(string title, string author) : base()
    {
        Title = title;
        _author = author;
    }
    public override void Display()
    {
        Console.WriteLine($"Blog Post: {Title} by {Author}");
    }
}
