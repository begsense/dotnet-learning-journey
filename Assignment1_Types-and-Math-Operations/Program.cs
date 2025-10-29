//First Part
int myAge = 28;
string myName = "Begi Kopaliani";
double myHeight = 1.77;
bool isStudent = false;
char myNameInitial = 'B';
byte myShoeSize = 41;
sbyte lostWeight = -3;
short lostWeightInGrams = -3000;
ushort myBirthYear = 1997;
uint myAnnualSalary = 3800;
long myBankBalance = -7000;
ulong myCountryPopulation = 3670000;
float myWeight = 73.5f;
decimal myNetWorth = 12000m;

Console.WriteLine($"Hi my name is: {myName}, I'm {myAge} years old, {myHeight}m tall, and I weigh {myWeight}kg. My initial is '{myNameInitial}' and I wear size {myShoeSize} shoes. I was born in {myBirthYear} and I'm {(isStudent ? "currently" : "not")} a student. I recently lost {Math.Abs(lostWeight)}kg ({Math.Abs(lostWeightInGrams)}g). My annual salary is {myAnnualSalary} Gel, my bank balance is {myBankBalance} Gel, and my net worth is {myNetWorth} Gel. I live in a country with {myCountryPopulation} people.");


//Second Part
int number1 = 15;
int number2 = 7;

int sum = number1 + number2;
int difference = number1 - number2;
int product = number1 * number2;
int quotient = number1 / number2; // integer division (without remainder)
int remainder = number1 % number2; // remainder from division

Console.WriteLine($"Given numbers' sum is: {sum}, difference is {difference}, product is {product}, quotient is {quotient}, and remainder is {remainder}");


//Third Part
double price = 17.99;
double quantity = 4;
double totalCost = price * quantity;
double discount = totalCost * 0.20;
double finalPrice = totalCost - discount;

Console.WriteLine($"The total cost for {quantity} items at {price} gel each is {totalCost}. After a 20% discount of {discount}, the final price is {finalPrice} gel.");