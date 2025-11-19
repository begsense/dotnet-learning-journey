using Assignment9_LINQ.Models;

# region mockData
List<NetworkLog> logs = new List<NetworkLog>
{
    new NetworkLog(1, new DateTime(2025,11,12,10,15,0), "10.0.0.5", "192.168.1.1", 22, "TCP", LogEntryStatus.Failed, 0, new List<string>{ "ERR_AUTH" }),
    new NetworkLog(2, new DateTime(2025,11,12,10,16,0), "10.0.0.5", "192.168.1.1", 22, "TCP", LogEntryStatus.Failed, 0, new List<string>{ "ERR_AUTH" }),
    new NetworkLog(3, new DateTime(2025,11,12,10,17,0), "10.0.0.5", "192.168.1.1", 22, "TCP", LogEntryStatus.Failed, 0, new List<string>{ "ERR_AUTH" }),
    new NetworkLog(4, new DateTime(2025,11,12,10,18,0), "10.0.0.5", "192.168.1.1", 22, "TCP", LogEntryStatus.Failed, 0, new List<string>{ "ERR_AUTH" }),
    new NetworkLog(5, new DateTime(2025,11,12,10,19,0), "10.0.0.5", "192.168.1.1", 22, "TCP", LogEntryStatus.Failed, 0, new List<string>{ "ERR_AUTH" }),
    new NetworkLog(6, new DateTime(2025,11,12,10,20,0), "10.0.0.5", "192.168.1.1", 22, "TCP", LogEntryStatus.Failed, 0, new List<string>{ "ERR_AUTH" }),
    new NetworkLog(7, new DateTime(2025,11,12,9,45,0), "10.0.0.9", "192.168.1.1", 22, "TCP", LogEntryStatus.Failed, 0, new List<string>{ "ERR_TIMEOUT" }),
    new NetworkLog(8, new DateTime(2025,11,12,9,46,0), "10.0.0.9", "192.168.1.1", 22, "TCP", LogEntryStatus.Failed, 0, new List<string>{ "ERR_TIMEOUT" }),
    new NetworkLog(9, new DateTime(2025,11,12,9,47,0), "10.0.0.9", "192.168.1.1", 22, "TCP", LogEntryStatus.Success, 5, new List<string>()),

    new NetworkLog(10, new DateTime(2025,11,12,11,0,0), "192.168.1.50", "8.8.8.8", 443, "TCP", LogEntryStatus.Success, 1200, new List<string>()),
    new NetworkLog(11, new DateTime(2025,11,12,11,5,0), "192.168.1.51", "10.10.10.10", 443, "TCP", LogEntryStatus.Success, 800, new List<string>()),
    new NetworkLog(12, new DateTime(2025,11,12,11,10,0), "192.168.1.52", "192.168.1.7", 443, "TCP", LogEntryStatus.Success, 900, new List<string>()),
    new NetworkLog(13, new DateTime(2025,11,12,11,15,0), "192.168.1.53", "172.16.0.1", 443, "TCP", LogEntryStatus.Success, 300, new List<string>()),

    new NetworkLog(14, new DateTime(2025,11,12,8,0,0), "10.0.0.10", "192.168.1.1", 22, "TCP", LogEntryStatus.Failed, 0, new List<string>()),
    new NetworkLog(15, new DateTime(2025,11,12,8,1,0), "10.0.0.10", "192.168.1.1", 80, "TCP", LogEntryStatus.Failed, 0, new List<string>()),
    new NetworkLog(16, new DateTime(2025,11,12,8,2,0), "10.0.0.10", "192.168.1.1", 80, "TCP", LogEntryStatus.Failed, 0, new List<string>()),
    new NetworkLog(17, new DateTime(2025,11,12,8,3,0), "10.0.0.10", "192.168.1.1", 443, "TCP", LogEntryStatus.Failed, 0, new List<string>()),
    new NetworkLog(18, new DateTime(2025,11,12,8,4,0), "10.0.0.10", "192.168.1.1", 80, "TCP", LogEntryStatus.Failed, 0, new List<string>()),

    new NetworkLog(19, new DateTime(2025,11,12,14,0,0), "10.0.0.20", "192.168.1.2", 22, "TCP", LogEntryStatus.Failed, 0, new List<string>{ "ERR_AUTH", "ERR_TIMEOUT" }),
    new NetworkLog(20, new DateTime(2025,11,12,14,1,0), "10.0.0.21", "192.168.1.3", 22, "TCP", LogEntryStatus.Failed, 0, new List<string>{ "ERR_AUTH", "ERR_AUTH" }),
    new NetworkLog(21, new DateTime(2025,11,12,14,2,0), "10.0.0.22", "192.168.1.4", 22, "TCP", LogEntryStatus.Failed, 0, new List<string>{ "ERR_TIMEOUT" }),
    new NetworkLog(22, new DateTime(2025,11,12,14,3,0), "10.0.0.23", "192.168.1.5", 22, "TCP", LogEntryStatus.Failed, 0, new List<string>{ "ERR_AUTH", "ERR_CONNRESET" }),
    new NetworkLog(23, new DateTime(2025,11,12,14,4,0), "10.0.0.24", "192.168.1.6", 22, "TCP", LogEntryStatus.Failed, 0, new List<string>{ "ERR_CONNRESET" }),

    new NetworkLog(24, new DateTime(2025,11,12,9,0,0), "10.0.0.25", "192.168.1.1", 22, "TCP", LogEntryStatus.Success, 10, new List<string>()),
    new NetworkLog(25, new DateTime(2025,11,12,9,10,0), "10.0.0.26", "192.168.1.1", 22, "TCP", LogEntryStatus.Success, 15, new List<string>()),
    new NetworkLog(26, new DateTime(2025,11,12,9,20,0), "10.0.0.27", "192.168.1.1", 22, "TCP", LogEntryStatus.Success, 20, new List<string>()),
    new NetworkLog(27, new DateTime(2025,11,12,14,0,0), "10.0.0.28", "192.168.1.1", 22, "TCP", LogEntryStatus.Success, 5, new List<string>()),

    new NetworkLog(28, new DateTime(2025,11,12,12,0,0), "10.0.0.30", "8.8.4.4", 443, "TCP", LogEntryStatus.Blocked, 2000, new List<string>()),
    new NetworkLog(29, new DateTime(2025,11,12,12,1,0), "10.0.0.31", "8.8.8.8", 443, "TCP", LogEntryStatus.Blocked, 1500, new List<string>()),
    new NetworkLog(30, new DateTime(2025,11,12,12,2,0), "10.0.0.32", "8.8.8.8", 443, "TCP", LogEntryStatus.Blocked, 3000, new List<string>()),
    new NetworkLog(31, new DateTime(2025,11,12,12,3,0), "10.0.0.33", "8.8.8.8", 443, "TCP", LogEntryStatus.Blocked, 4000, new List<string>()),
    new NetworkLog(32, new DateTime(2025,11,12,12,4,0), "10.0.0.34", "8.8.8.8", 443, "TCP", LogEntryStatus.Blocked, 3500, new List<string>()),
    new NetworkLog(33, new DateTime(2025,11,12,12,5,0), "10.0.0.35", "8.8.8.8", 443, "TCP", LogEntryStatus.Blocked, 500, new List<string>()),

    new NetworkLog(34, new DateTime(2025,11,12,13,0,0), "10.0.0.40", "8.8.8.8", 53, "UDP", LogEntryStatus.Success, 1200, new List<string>())
};
#endregion

void TextVisualizer(string title, ConsoleColor color)
{
    Console.WriteLine("===================================");
    Console.BackgroundColor = color;
    Console.WriteLine(title);
    Console.ResetColor();
}

void WaitForUser()
{
    Console.WriteLine("Press any key to return to the menu...");
    Console.ReadKey();
}

void DisplayMenu()
{
    Console.WriteLine("Select an analytical report to generate:");
    Console.WriteLine("1. Detect 'Brute-Force' Attacks");
    Console.WriteLine("2. Data Exfiltration Analysis");
    Console.WriteLine("3. Port Scanning Analysis");
    Console.WriteLine("4. Most Common Error Codes");
    Console.WriteLine("5. Peak Hour Determination");
    Console.WriteLine("6. Risk Ranking");
    Console.WriteLine("7. Anomalous Protocols Check");
    Console.WriteLine("0. Exit");
}

while (true)
{
    TextVisualizer("Hello User, Welcome", ConsoleColor.DarkCyan);

    Console.ForegroundColor = ConsoleColor.Yellow;

    DisplayMenu();

    Console.ResetColor();

    Console.Write("Enter your choice: ");

    var choice = Console.ReadLine();

    if (choice == "0")
    {
        break;
    }

    switch (choice)
    {
        case "1":
            TextVisualizer("Brute-Force Attack Detection", ConsoleColor.DarkRed);
            var bruteForce = logs
                .Where(l => l.Status == LogEntryStatus.Failed)
                .GroupBy(l => l.SourceIP)
                .Select(g => new { SourceIP = g.Key, FailedCount = g.Count() })
                .Where(x => x.FailedCount > 5)
                .OrderByDescending(x => x.FailedCount);

            foreach (var item in bruteForce)
                Console.WriteLine($"IP: {item.SourceIP}, Failed Attempts: {item.FailedCount}");
            WaitForUser();
            break;

        case "2":
            TextVisualizer("Data Exfiltration Analysis", ConsoleColor.DarkGreen);
            var totalExfilKB = logs
                .Where(l => l.Status == LogEntryStatus.Success && !l.DestinationIP.StartsWith("192.168"))
                .Sum(l => l.DataTransferredKB);

            Console.WriteLine($"Total external data exfiltrated: {totalExfilKB} KB");
            WaitForUser();
            break;

        case "3":
            TextVisualizer("Port Scanning Analysis", ConsoleColor.DarkYellow);
            var portScan = logs
                .Where(l => l.DestinationIP == "192.168.1.1")
                .GroupBy(l => l.Port)
                .Select(g => new { Port = g.Key, Attempts = g.Count() })
                .OrderByDescending(x => x.Attempts);

            foreach (var p in portScan)
                Console.WriteLine($"Port {p.Port} -> {p.Attempts} attempts");
            WaitForUser();
            break;

        case "4":
            TextVisualizer("Most Common Error Codes", ConsoleColor.DarkMagenta);
            var commonErrors = logs
                .SelectMany(l => l.ErrorCodes)
                .GroupBy(code => code)
                .Select(g => new { ErrorCode = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .Take(3);

            Console.WriteLine("Top 3 most frequent error codes:");
            foreach (var e in commonErrors)
                Console.WriteLine($"{e.ErrorCode}: {e.Count} times");
            WaitForUser();
            break;

        case "5":
            TextVisualizer("Peak Hour Determination", ConsoleColor.DarkCyan);
            var peakHour = logs
                .GroupBy(l => l.Timestamp.Hour)
                .Select(g => new { Hour = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .FirstOrDefault();

            if (peakHour != null)
                Console.WriteLine($"Peak hour: {peakHour.Hour}:00 with {peakHour.Count} logs");
            else
                Console.WriteLine("No data available.");
            WaitForUser();
            break;

        case "6":
            TextVisualizer("Risk Ranking (Top 10 Blocked by Size)", ConsoleColor.DarkBlue);
            var risks = logs
                .Where(l => l.Status == LogEntryStatus.Blocked)
                .OrderByDescending(l => l.DataTransferredKB)
                .Take(10);

            foreach (var r in risks)
                Console.WriteLine($"[{r.LogId}] {r.SourceIP} -> {r.DestinationIP}, {r.DataTransferredKB} KB, {r.Status}");
            WaitForUser();
            break;

        case "7":
            TextVisualizer("Anomalous Protocol Check", ConsoleColor.Gray);
            bool hasAnomaly = logs.Any(l =>
                l.Protocol == "UDP" &&
                l.Status == LogEntryStatus.Success &&
                l.DataTransferredKB > 1000);

            Console.WriteLine($"Anomalous UDP success found? {hasAnomaly}");
            WaitForUser();
            break;

        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }

}

TextVisualizer("Thank you for using the Network Log Analyzer. Goodbye!", ConsoleColor.DarkCyan);