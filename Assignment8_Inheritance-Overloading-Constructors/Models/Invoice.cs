namespace Assignment8_Inheritance_Overloading_Constructors.Models;

internal class Invoice: Document
{
    private double _amount;
    public double Amount
    {
        get { return _amount; }
        set { _amount = value; }
    }
    public Invoice(string title, double amount) : base(title)
    {
        _amount = amount;
    }
    public void PrintInvoice()
    {
        Console.WriteLine($"Invoice for {Title} - Amount: {Amount}");
    }
}
