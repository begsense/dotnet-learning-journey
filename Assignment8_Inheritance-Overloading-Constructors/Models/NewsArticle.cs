namespace Assignment8_Inheritance_Overloading_Constructors.Models;

internal class NewsArticle : Post
{
    private string _source;
    public string Source
    {
        get { return _source; }
        set { _source = value; }
    }
    public NewsArticle(string title, string source) : base()
    {
        Title = title;
        _source = source;
    }
    public override void Display()
    {
        Console.WriteLine($"News: {Title} (Source: {Source})");
    }
}
