namespace Lecture14.Models;

internal class Hero
{
    private int id = 1;
    private string name;
    private string cartoon;
    private int width;
    private int height;
    private double price;
    private int quantity;
    public int Id
    {
        get { return id + 1; }
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public string Cartoon
    {
        get { return cartoon; }
        set { cartoon = value; }
    }
    public int Width
    {
        get { return width; }
        set { width = value; }
    }
    public int Height
    {
        get { return height; }
        set { height = value; }
    }
    public double Price
    {
        get { return price; }
        private set { price = value; }
    }
    public int Quantity
    {
        get { return quantity; }
        set { quantity = value; }
    }


    public void SetPrice(double newPrice, User currentUser)
    {
        if (!currentUser.IsAdmin)
        {
            Console.WriteLine("Only admins can set the price.");
        } else
        {
            Price = newPrice;
        }
    }
}
