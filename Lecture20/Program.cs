using Lecture20.Helpers;

Logging logger = new Logging();

while (true)
{
    Console.WriteLine("1. Read Logs?");
    Console.WriteLine("2. Log Information?");
    Console.WriteLine("3. Exit");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            logger.ReadLogs();
            break;
        case "2":
            Console.WriteLine("Enter information to log:");
            string info = Console.ReadLine();
            logger.Log(info);
            break;
        case "3":
            return;
        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }
}