namespace Assignment6_Encapsulation.Models;
class Burger
{
    private string _name;
    private decimal _price;
    private int _calories;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public decimal Price
    {
        get { return _price; }
    }
    public int Calories
    {
        get { return _calories; }
    }

    public void SetPrice(decimal price)
    {
        if (price >= 0)
        {
            _price = price;
        }
    }

    public void SetCalories(int calories)
    {
        if (calories >= 0)
        {
            _calories = calories;
        }
    }
}