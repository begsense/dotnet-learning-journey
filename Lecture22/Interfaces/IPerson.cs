namespace Lecture22.Interfaces;

internal interface IPerson
{
    int Age { get; set; }
    void SayHello();

    void SayGoodbye();

    void LogIn();
}
