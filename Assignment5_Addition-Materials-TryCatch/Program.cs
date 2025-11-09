// calculator with learning error handling and file writing

while (true)
{
    TextColorChanger(text: "Simple Calculator Application", color: ConsoleColor.Cyan);

    try
    {
        TextColorChanger(text: "Enter first number: ", color: ConsoleColor.Yellow);
        double num1 = Convert.ToDouble(Console.ReadLine());

        TextColorChanger(text: "Enter second number: ", color: ConsoleColor.Yellow);
        double num2 = Convert.ToDouble(Console.ReadLine());

        TextColorChanger(text: "Enter operator (+, -, *, /): ", color: ConsoleColor.Yellow);
        string op = Console.ReadLine();

        double result = 0;
        switch (op)
        {
            case "+":
                result = num1 + num2;
                break;
            case "-":
                result = num1 - num2;
                break;
            case "*":
                result = num1 * num2;
                break;
            case "/":
                if (num2 == 0)
                {
                    throw new DivideByZeroException("Cannot divide by zero.");
                }
                result = num1 / num2;
                break;
            default:
                throw new InvalidOperationException("Invalid operator.");
        }

        TextColorChanger(text: $"Result: {result}", color: ConsoleColor.Green);

        TextColorChanger(text: "Do you want to save the result to a file? (y/n): ", color: ConsoleColor.Yellow);

        string saveToFile = Console.ReadLine();

        if (saveToFile.ToLower() == "y")
        {
            string content = $"{num1} {op} {num2} = {result}";
            WriteToFile(content);
            TextColorChanger(text: "Result saved to calculation_history.txt", color: ConsoleColor.Green);
        }

        TextColorChanger(text: "Do you want to read the calculation history? (y/n): ", color: ConsoleColor.Yellow);

        string readFromFile = Console.ReadLine();

        if (readFromFile.ToLower() == "y")
        {
            ReadFromFile();
        }
    }

    catch (FormatException)
    {
        TextColorChanger(text: "Input was not in a correct format. Please enter numeric values.", color: ConsoleColor.Red);
    }

    catch (DivideByZeroException ex)
    {
        TextColorChanger(text: ex.Message, color: ConsoleColor.Red);
    }

    catch (InvalidOperationException ex)
    {
        TextColorChanger(text: ex.Message, color: ConsoleColor.Red);
    }

    catch (Exception ex)
    {
        TextColorChanger(text: $"An unexpected error occurred: {ex.Message}", color: ConsoleColor.Red);
    }

    TextColorChanger(text: "Do you want to perform another calculation? (y/n): ", color: ConsoleColor.Yellow);
    string continueCalc = Console.ReadLine();

    if (continueCalc.ToLower() != "y")
    {
        Console.WriteLine("Bye bye!");
        break;
    }
}


void TextColorChanger(string text, ConsoleColor color)
{
    Console.ForegroundColor = color;
    Console.WriteLine(text);
    Console.ResetColor();
}

void WriteToFile(string content, string fileName = "calculation_history.txt")
{
    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    string fullPath = Path.Combine(desktopPath, fileName);

    try
    {
        File.AppendAllText(fullPath, content + Environment.NewLine);
    }

    catch (Exception ex)
    {
        TextColorChanger(text: $"An unexpected file error occurred: {ex.Message}", color: ConsoleColor.Magenta);
    }
}



void ReadFromFile(string fileName = "calculation_history.txt")
{
    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    string fullPath = Path.Combine(desktopPath, fileName);

    try
    {
        if (File.Exists(fullPath))
        {
            string[] lines = File.ReadAllLines(fullPath);
            TextColorChanger(text: "Calculation History:", color: ConsoleColor.Blue);



            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
        else
        {
            TextColorChanger(text: "No calculation history found.", color: ConsoleColor.Blue);
        }
    }

    catch (Exception ex)
    {
        TextColorChanger(text: $"An unexpected file error occurred: {ex.Message}", color: ConsoleColor.Magenta);
    }
}