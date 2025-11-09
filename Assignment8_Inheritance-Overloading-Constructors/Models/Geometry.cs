namespace Assignment8_Inheritance_Overloading_Constructors.Models;

internal class Geometry
{
    public void DiagnoseShape(int a)
    {
        Console.WriteLine("This is a shape with 1 dimension.");
    }

    public void DiagnoseShape(int a, int b)
    {
        if (a == b)
        {
            Console.WriteLine("This is a square.");
        }
        else
        {
            Console.WriteLine("This is a rectangle.");
        }
    }

    public void DiagnoseShape(int a, int b, int c)
    {
        if (a == b && b == c)
        {
            Console.WriteLine("This is an equilateral triangle.");
        }
        else if (a == b || b == c || a == c)
        {
            Console.WriteLine("This is an isosceles triangle.");
        }
        else
        {
            Console.WriteLine("This is a scalene triangle.");
        }
    }
}
