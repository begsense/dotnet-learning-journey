namespace Assignment8_Inheritance_Overloading_Constructors.Models;

internal class Document
{
    protected string Title;
    public Document(string title)
    {
        Title = title;
    }
    public void PrintHeader()
    {
        Console.WriteLine($"Document Title: {Title}");
    }
}
