using DevTracker_Final_ConsoleApp.Interfaces;

namespace DevTracker_Final_ConsoleApp.FileLogging;

internal class Logger : ILogger
{
    public void Log(string message)
    {
        using (StreamWriter sw = new StreamWriter(@"D:\ITStepDotNet\DevTracker_Final-ConsoleApp\Logs\logs.txt", true))
        {
            sw.WriteLine($"[{DateTime.UtcNow}] | {message} ");
        }
    }
}
