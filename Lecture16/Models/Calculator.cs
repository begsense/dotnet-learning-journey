namespace Lecture16.Models;

internal class Calculator
{
    public void Add(int a, int b)
    {
        int result = a + b;
        Console.WriteLine($"The sum of {a} and {b} is {result}");
    }

    public void Add(double a, double b)
    {
        double result = a + b;
        Console.WriteLine($"The sum of {a} and {b} is {result}");
    }

    public void Add(int a, int b, int c)
    {
        int result = a + b + c;
        Console.WriteLine($"The sum of {a}, {b}, and {c} is {result}");
    }
}
