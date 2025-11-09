namespace Assignment8_Inheritance_Overloading_Constructors.Models;

internal class Manager : Employee
{
    private double _bonus;

    public double Bonus
    {
        get { return _bonus; }
        set { _bonus = value; }
    }

    public override double CalculateSalary()
    {
        return BaseSalary + Bonus;
    }
}
