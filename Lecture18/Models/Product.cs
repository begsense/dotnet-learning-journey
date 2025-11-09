namespace Lecture18.Models;

internal class Product
{
    private string _name;
    private string _category;
    private decimal _price;
    private int _stockQuantity;

    public Product(string name, string category, decimal price, int stockQuantity)
    {
        Name = name;
        Category = category;
        Price = price;
        StockQuantity = stockQuantity;
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public string Category
    {
        get { return _category; }
        set { _category = value; }
    }

    public decimal Price
    {
        get { return _price; }
        set { _price = value; }
    }

    public int StockQuantity
    {
        get { return _stockQuantity; }
        set { _stockQuantity = value; }
    }
}
