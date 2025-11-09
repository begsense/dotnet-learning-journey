namespace Assignment8_Inheritance_Overloading_Constructors.Models;

internal class Car
{
    private string _model;
    private int _year;
    private string _color;

    public string Model
    {
        get { return _model; }
        set { _model = value; }
    }

    public int Year
    {
        get { return _year; }
        set { _year = value; }
    }

    public string Color
    {
        get { return _color; }
        set { _color = value; }
    }

    public Car(string model, int year)
    {
        Model = model;
        Year = year;
        Color = "Black";
    }

    public Car(string model, int year, string color) : this(model, year)
    {
        Color = color;
    }
}
