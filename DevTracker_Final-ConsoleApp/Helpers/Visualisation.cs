namespace DevTracker_Final_ConsoleApp.Helpers;

internal class Visualisation
{
    public void WriteColored(string text, ConsoleColor? foregroundColor = null, ConsoleColor? backgroundColor = null, bool? line = true)
    {
        if (foregroundColor != null)
        {
            Console.ForegroundColor = foregroundColor.Value;
        }
        if (backgroundColor != null)
        {
            Console.BackgroundColor = backgroundColor.Value;
        }

        if (line == true)
        {
            Console.WriteLine(text);
        }
        else
        {
            Console.Write(text);
        }

        Console.ResetColor();
    }

    public void ClearOnClick()
    {
        Console.ReadKey();
        Console.Clear();
    }
}
