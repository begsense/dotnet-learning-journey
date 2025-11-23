namespace DevTracker_Final_ConsoleApp.Helpers;

internal class Visualisation
{
    public void WriteColored(string text, ConsoleColor? foregroundColor = null, ConsoleColor? backgroundColor = null)
    {
        if (foregroundColor != null)
        {
            Console.ForegroundColor = foregroundColor.Value;
        }
        if (backgroundColor != null)
        {
            Console.BackgroundColor = backgroundColor.Value;
        }
        Console.WriteLine(text);
        Console.ResetColor();
    }
}
