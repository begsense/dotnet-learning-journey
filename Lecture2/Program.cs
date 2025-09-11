//CTRL K C  / CTRL K U
//Types

string userName = "Begi";

Console.WriteLine($"Hello, {userName}!");

byte userAge = 36;
sbyte temperature = -10;
short balance = -2000;
ushort maxFiles = 5000;

Console.WriteLine($"Your age is {userAge}, temperature is {temperature}, balance is {balance}, max files is {maxFiles}");

int population = 100000;
uint fileSize = 4000000;
long distance = 10000000000;
ulong starsInGalaxy = 1000000000000;

Console.WriteLine($"Population is {population}, file size is {fileSize}, distance is {distance}, stars in galaxy is {starsInGalaxy}");

int intNumber = 3333333;
float floatNumber = 3.14f;
double doubleNumber = 3.14;
decimal decimalNumber = 3.14m;

Console.WriteLine($"Int: {intNumber}, Float: {floatNumber}, Double: {doubleNumber}, Decimal: {decimalNumber}");

char letter = 'A';
bool isRaining = false;

Console.WriteLine($"Letter: {letter}, Is it raining? {isRaining}");


//Math Operations
int a = 10;
int b = 3;
int sum = a + b;
Console.WriteLine($"Sum: {sum}");
Console.WriteLine($"Difference: {a - b}");
Console.WriteLine($"Product: {a * b}");
Console.WriteLine($"Quotient: {a / b}");
Console.WriteLine($"Remainder: {a % b}");