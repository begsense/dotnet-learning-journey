namespace Lecture21.Models;

internal class Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public virtual void CalculateArea()
    {
        Console.WriteLine("Calculating area of a generic shape.");
    }
}
