namespace Assignment8_Inheritance_Overloading_Constructors.Models;

internal class Employee
{
    private string _name;
    private double _baseSalary;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public double BaseSalary
    {
        get { return _baseSalary; }
        set { _baseSalary = value; }
    }

    public virtual double CalculateSalary()
    {
        return BaseSalary;
    }
}
