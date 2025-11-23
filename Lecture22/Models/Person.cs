using Lecture22.Interfaces;
namespace Lecture22.Models;

internal class Person : IPerson, IHuman
{
    public int Age { get; set; }

    public void SayHello()
    {
        Console.WriteLine("Saying Hello");
    }

    public void SayGoodbye()
    {
        Console.WriteLine("Saying Goodbye");
    }

    public void LogIn()
    {
        Console.WriteLine("Login");
    }

    public void Breath()
    {
        Console.WriteLine("Breathing");
    }

    public void Think()
    {
        Console.WriteLine("Thinking");
    }
}
