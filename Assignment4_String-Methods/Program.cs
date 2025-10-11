//1. Email Validator
string atSymbol = "@";
string[] targetEndPoints = { ".com", ".ge", ".edu" };

Console.Write("Enter Email please: ");

string userInput = Console.ReadLine().ToLower().Trim();
int lastIndexOfSymbol = userInput.LastIndexOf(atSymbol);
int displayIndex = lastIndexOfSymbol == -1 ? 0 : lastIndexOfSymbol;

Console.WriteLine("====================================");

if (userInput.Contains(atSymbol))
{
    Console.WriteLine($"Input Constains {atSymbol}");
}
else
{
    Console.WriteLine($"Input Does Not Constain {atSymbol}");
}
for (int i = 0; i < targetEndPoints.Length; i++)
{
    if (userInput.EndsWith(targetEndPoints[i]))
    {
        Console.WriteLine($"Input Ends With {i} target EndPoint: {targetEndPoints[i]}");
    }
    else
    {
        Console.WriteLine($"Input Does Not End With {i} target EndPoint: {targetEndPoints[i]}");
    }
}
if (lastIndexOfSymbol > 2)
{
    Console.WriteLine($"Yes! Before {atSymbol} is More then 2 symbols and it is {displayIndex}");
}
else
{
    Console.WriteLine($"No! Before {atSymbol} is Less then 2 symbols and it is {displayIndex}");
}
if (userInput.Length - lastIndexOfSymbol - 1 > 2 && lastIndexOfSymbol > 0)
{
    Console.WriteLine($"Yes! After {atSymbol} is More then 2 symbols and it is {userInput.Length - displayIndex - 1}");
}
else
{
    if (lastIndexOfSymbol == -1)
    {
        Console.WriteLine($"No! There is No {atSymbol} in the input");
    }
    else
    {
        Console.WriteLine($"No! After {atSymbol} is Less then 2 symbols and it is {userInput.Length - displayIndex - 1}");
    }
}


Console.WriteLine("====================================");
//2. Password Strength Validator
Console.Write("Enter Password please: ");
string passwordInput = Console.ReadLine().Trim();

int score = 0;
if (passwordInput.Length >= 8)
{
    score++;
    Console.WriteLine("Password has minimum 8 characters.");
}
else
{
    Console.WriteLine("Password does not have minimum 8 characters.");
}
if (passwordInput != passwordInput.ToLower())
{
    score++;
    Console.WriteLine("Password contains at least one uppercase letter.");
}
else
{
    Console.WriteLine("Password does not contain any uppercase letters.");
}
if (passwordInput.Contains("0") || passwordInput.Contains("1") || passwordInput.Contains("2") || passwordInput.Contains("3") 
    || passwordInput.Contains("4") || passwordInput.Contains("5") || passwordInput.Contains("6") || passwordInput.Contains("7") 
    || passwordInput.Contains("8") || passwordInput.Contains("9"))
{
    score++;
    Console.WriteLine("Password contains at least one digit.");
}
else
{
    Console.WriteLine("Password does not contain any digits.");
}

Console.WriteLine("====================================");
if (score <= 1)
{
    Console.WriteLine("Password Strength: Weak");
}
else if (score == 2)
{
    Console.WriteLine("Password Strength: Medium");
}
else
{
    Console.WriteLine("Password Strength: Strong");
}


Console.WriteLine("====================================");
//3. Censured Words
string[] badWords = { "spam", "virus", "hack" };

Console.Write("Enter your comment: ");
string commentInput = Console.ReadLine().ToLower().Trim();

string cleanComment = commentInput;
for (int i = 0; i < badWords.Length; i++)
{
    if (cleanComment.Contains(badWords[i]))
    {
        cleanComment = cleanComment.Replace(badWords[i], "***");
    }
}

Console.WriteLine("Clean Comment: " + cleanComment);


Console.WriteLine("====================================");
//4. Format Full Name
Console.Write("Enter your full name: ");
string fullNameInput = Console.ReadLine().ToLower().Trim();

string[] nameParts = fullNameInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
if (nameParts.Length >= 2)
{
    string firstName = char.ToUpper(nameParts[0][0]) + nameParts[0].Substring(1).ToLower();
    string lastName = char.ToUpper(nameParts[1][0]) + nameParts[1].Substring(1).ToLower();
    string formattedName = $"Hello Mister {lastName} {firstName[0]}.";
    Console.WriteLine(formattedName);
}
else
{
    Console.WriteLine("Please enter both your first and last name.");
}


Console.WriteLine("====================================");
//5. Files Filter
string[] files = {"photo.jpg", "document.pdf", "video.mp4",
                  "music.mp3", "archive.zip", "image.jpg"};
string fileInput = Console.ReadLine().ToLower().Trim();

int fileCount = 0;
for (int i = 0; i < files.Length; i++)
{
    if (files[i].EndsWith(fileInput))
    {
        Console.WriteLine(files[i]);
        fileCount++;
    }
}

Console.WriteLine($"Total files found: {fileCount}");


Console.WriteLine("====================================");
//6. CSV Parser and Statistics
string data = "Giorgi,25,1500;Ana,30,2000;Davit,22,1200;Mari,28,1800";
string[] filteredData = data.Split(';', StringSplitOptions.RemoveEmptyEntries);

int totalEmployees = filteredData.Length;
int totalAge = 0;
int maxSalary = int.MinValue;
int minSalary = int.MaxValue;

string[] namesStartingWithD = new string[totalEmployees];
for (int i = 0; i < filteredData.Length; i++)
{
    string[] parts = filteredData[i].Split(',', StringSplitOptions.RemoveEmptyEntries);
    if (parts.Length == 3)
    {
        string name = parts[0];
        int age = int.Parse(parts[1]);
        int salary = int.Parse(parts[2]);
        totalAge += age;
        if (salary > maxSalary) maxSalary = salary;
        if (salary < minSalary) minSalary = salary;
        if (name.StartsWith("D", StringComparison.OrdinalIgnoreCase))
        {
            namesStartingWithD[i] = name;
        }
    }
}

double averageAge = (double)totalAge / totalEmployees;

Console.WriteLine($"Total Employees: {totalEmployees}");
Console.WriteLine($"Average Age: {averageAge:F2}");
Console.WriteLine($"Max Salary: {maxSalary}");
Console.WriteLine($"Min Salary: {minSalary}");
Console.WriteLine("Names starting with 'D':");
foreach (var name in namesStartingWithD)
{
    if (!string.IsNullOrEmpty(name))
    {
        Console.WriteLine(name);
    }
}


Console.WriteLine("====================================");
//7. URL Analysis
Console.Write("Enter a URL: ");
string urlInput = Console.ReadLine().ToLower().Trim();

bool isHttp = urlInput.StartsWith("http://");
bool isHttps = urlInput.StartsWith("https://");
int protocolEndIndex = isHttp ? 7 : isHttps ? 8 : -1;

if (protocolEndIndex != -1)
{
    int domainEndIndex = urlInput.IndexOf('/', protocolEndIndex);
    if (domainEndIndex == -1)
    {
        domainEndIndex = urlInput.Length;
    }
    string domain = urlInput.Substring(protocolEndIndex, domainEndIndex - protocolEndIndex);
    bool hasQueryString = urlInput.Contains("?");
    string path = domainEndIndex < urlInput.Length ? urlInput.Substring(domainEndIndex) : "";
    string[] pathSegments = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
    Console.WriteLine($"Protocol: {(isHttps ? "https" : "http")}");
    Console.WriteLine($"Domain: {domain}");
    Console.WriteLine($"Has Query String: {hasQueryString}");
    Console.WriteLine($"Path Segments Count: {pathSegments.Length}");
}
else
{
    Console.WriteLine("Invalid URL format.");
}


Console.WriteLine("====================================");
//8. Mobile Number Formater
Console.Write("Enter your mobile number: ");
string mobileInput = Console.ReadLine().Trim();
string cleanedNumber = mobileInput.Replace(" ", "").Replace("-", "");

if (cleanedNumber.Length == 9 && cleanedNumber.StartsWith("5"))
{
    string formattedNumber = $"({cleanedNumber.Substring(0, 3)}) {cleanedNumber.Substring(3, 2)}-{cleanedNumber.Substring(5, 2)}-{cleanedNumber.Substring(7, 2)}";
    Console.WriteLine($"Formatted Number: {formattedNumber}");
}
else
{
    Console.WriteLine("Invalid mobile number format.");
}

