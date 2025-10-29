namespace Lecture16.Models;

internal class Student: Person
{
    private double _gpa;

    public Student(double _gpa, string name) : base(name)
    {
        Gpa = _gpa;
    }

    public double Gpa
    {
        get { return _gpa; }
        set { _gpa = value; }
    }
}
