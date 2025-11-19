namespace Lecture20.Helpers;

internal class Logging
{
    public void Log(string message)
    {
        using (StreamWriter sw = new StreamWriter(@"C:\Users\user\Desktop\dotnet\logs.txt", true))
        {
            sw.WriteLine($"[{DateTime.UtcNow}]: {message}");
        }
    }

    public void ReadLogs()
    {
        using (StreamReader sr = new StreamReader(@"C:\Users\user\Desktop\dotnet\logs.txt"))
        {
            Console.WriteLine(sr.ReadLine());
        }
    }
}
