// loops
/*
for (int i = 0; i < 10; i++)
{
    Console.WriteLine(i);
}

for (int i = 0;i < 10; i+= 2)
{
    Console.WriteLine(i);
}

for (int i = 10; i <= 0; i--)
{
    Console.WriteLine(i); //0
}

string[] quotes =
{
    "Chkviani Kacis Sityvebi 1",
    "Chkviani Kacis Sityvebi 2",
    "Chkviani Kacis Sityvebi 3",
    "Chkviani Kacis Sityvebi 4",
    "Chkviani Kacis Sityvebi 5",
    "Chkviani Kacis Sityvebi 6"
};

for (int i = 0; i < quotes.Length; i++)
{
    Console.WriteLine(quotes[i]);
}

for (int i = quotes.Length - 1; i >= 0; i--)
{
    Console.WriteLine(quotes[i]);
}


decimal[] prices =
{
    500m,
    3.75m,
    1500m,
    3000m,
    900m,
    100m
};

decimal sum = 0;
decimal average = 0;

for (int i = 0; i < prices.Length; i++)
{
    sum += prices[i];
}

average = sum / prices.Length;

Console.WriteLine($"average is {average}");

for (int i = 0; i < prices.Length; i++)
{
    if (prices[i] > average)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{prices[i]} is more then average");
        Console.WriteLine($"price differ by: {prices[i] - average}");
        Console.ResetColor();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{prices[i]} is less then average");
        Console.WriteLine($"price differ by {average - prices[i]}");
        Console.ResetColor();
    }
    Console.WriteLine("-------------------------");
}
*/

// ClassWork

decimal[] productisFasebi = { 12.50m, 8.75m, 45.00m, 23.30m, 67.80m, 15.40m, 90.00m };
// დავალებები:
// 1. იპოვეთ მინიმალური ფასი
// 2. იპოვეთ მაქსიმალური ფასი
// 3. დათვალეთ რამდენი პროდუქტი ღირს 20 ლარზე ნაკლები
// 4. დათვალეთ რამდენი პროდუქტი ღირს 50 ლარზე მეტი

decimal minPrice = productisFasebi[0];
decimal maxPrice = productisFasebi[0];
decimal countLessThen20 = 0;
decimal countMoreThen50 = 0;

for (int i = 0; i < productisFasebi.Length; i++)
{
    if (productisFasebi[i] < minPrice)
    {
        minPrice = productisFasebi[i];
    }

    if (productisFasebi[i] > maxPrice)
    {
        maxPrice = productisFasebi[i];
    }

    if (productisFasebi[i] < 20)
    {
        countLessThen20++;
    }

    if (productisFasebi[i] > 50)
    {
        countMoreThen50++;
    }
}

Console.WriteLine($"Min price is {minPrice}, max price is {maxPrice}, less then 20 is {countLessThen20} and more then 50 is {countMoreThen50}");

Console.WriteLine("=======================================");


string[] productebi = { "puri", "rdze", "kvercxi", "yveli", "karaqi", "shaqari", "marili", "zeti" };
// დავალებები:
// 1. დაბეჭდეთ მხოლოდ კენტ ინდექსებზე მდგომი პროდუქტები
// 2. დაბეჭდეთ მხოლოდ ლუწ ინდექსებზე მდგომი პროდუქტები
// 3. დაბეჭდეთ პროდუქტები შებრუნებული თანმიმდევრობით

for (int i = 0; i < productebi.Length; i++)
{
    if (i % 2 != 0)
    {
        Console.WriteLine($"Kent Indexze ({i}) mdgomi produqtia : {productebi[i]}");
    }
    else
    {
        Console.WriteLine($"Luw Indexze ({i}) mdgomi produqtia : {productebi[i]}");
    }
}

Console.WriteLine("=======================================");

Console.WriteLine("Shemobrunebulad dalagebuli: ");

for (int i = productebi.Length - 1; i >= 0; i--)
{
    Console.WriteLine(productebi[i]);
}


Console.WriteLine("=======================================");

decimal[] originalFasebi = { 100m, 250m, 75m, 180m, 320m, 95m };
int fasdaklebisProcenti = 15; // 15% ფასდაკლება

// დავალებები:
// 1. გამოთვალეთ ახალი ფასები ფასდაკლების შემდეგ
// 2. გამოთვალეთ დანაზოგი თითოეულ პროდუქტზე
// 3. გამოთვალეთ ჯამური დანაზოგი
// 4. დაბეჭდეთ ძველი და ახალი ფასები ფერადად

decimal[] axaiwFasebi = new decimal[originalFasebi.Length];
decimal[] danazogi = new decimal[originalFasebi.Length];
decimal jamuriDanazogi = 0;

for (int i = 0; i < originalFasebi.Length; i++)
{
    danazogi[i] = (originalFasebi[i] * fasdaklebisProcenti) / 100;
    axaiwFasebi[i] = originalFasebi[i] - danazogi[i];
    jamuriDanazogi += danazogi[i];
}

Console.WriteLine("========================================");

for (int i = 0; i < axaiwFasebi.Length; i++)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"Axali Fasi: {axaiwFasebi[i]}");
    Console.ResetColor();
}


Console.WriteLine("=======================================");

int[] studentebisQulebi = { 85, 92, 78, 65, 90, 88, 72, 95, 60, 83 };
// საშუალო ქულა = 80

// დავალებები:
// 1. დათვალეთ რამდენმა სტუდენტმა გადალახა საშუალო ზღვარი
// 2. იპოვეთ საუკეთესო და უარესი ქულა
// 3. დაბეჭდეთ სტუდენტების ნომრები და მათი ქულები
// 4. მწვანედ აჩვენეთ 80+ ქულები, წითლად 60- ქულები
int averageScore = 80;
int countAboveAverage = 0;
int bestScore = studentebisQulebi[0];
int worstScore = studentebisQulebi[0];

for (int i = 0; i < studentebisQulebi.Length; i++)
{
    if (studentebisQulebi[i] > averageScore)
    {
        countAboveAverage++;
    }

    if (studentebisQulebi[i] > bestScore)
    {
        bestScore = studentebisQulebi[i];
    }

    if (studentebisQulebi[i] < worstScore)
    {
        worstScore = studentebisQulebi[i];
    }

    if (studentebisQulebi[i] >= 80)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Studenti {i + 1} - is {studentebisQulebi[i]}");
        Console.ResetColor();
    }
    else if (studentebisQulebi[i] < 60)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Studenti {i + 1} - is {studentebisQulebi[i]}");
        Console.ResetColor();
    }
    else
    {
        Console.WriteLine($"Studenti {i + 1} - is {studentebisQulebi[i]}");
    }
}


Console.WriteLine("=======================================");

int[] ricxvebi = { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50 };
// დავალებები:
// 1. დაბეჭდეთ ყოველი მეორე რიცხვი
// 2. გაამრავლეთ თითოეული რიცხვი 2-ზე და დაბეჭდეთ
// 3. დაბეჭდეთ მხოლოდ ის რიცხვები, რომლებიც იყოფა 3-ზე
// 4. დაბეჭდეთ რიცხვები უკუღმა (50-დან 5-მდე)
for (int i = 0; i < ricxvebi.Length; i++)
{
    if (i % 2 == 1)
    {
        Console.WriteLine($" yovel meore ricxvshi shedioda: {ricxvebi[i]}");
    }

    Console.WriteLine($"{ricxvebi[i]} gamravlebuli 2ze aris:  {ricxvebi[i] * 2}");

    if (ricxvebi[i] % 3 == 0)
    {
        Console.WriteLine($"{ricxvebi[i]} iyofa 3ze unashtod");
    }
}

Console.WriteLine("=======================================");

Console.WriteLine("Ricxvebi ukugma: ");

for (int i = ricxvebi.Length - 1; i >= 0; i--)
{
    Console.WriteLine(ricxvebi[i]);
}


Console.WriteLine("=======================================");

string[] menu = { "burgeri", "pizza", "salata", "sushi", "pasta", "steiki" };
decimal[] fasebi = { 18.50m, 22.00m, 12.50m, 35.00m, 16.80m, 45.00m };

// დავალებები:
// 1. აჩვენეთ მენიუ ნომრებით (1. burgeri - 18.50 ლ)
// 2. იპოვეთ ყველაზე ძვირი და იაფი კერძი
// 3. გამოთვალეთ თუ ყველა კერძს შეუკვეთენ, რა ჯამი გამოვა
// 4. აჩვენეთ კერძები ფასების მიხედვით (იაფიდან ძვირისკენ)
// 5. ფერადად აჩვენეთ: მწვანე <20ლ, ყვითელი 20-30ლ, წითელი >30ლ
decimal minFasi = fasebi[0];
decimal maxFasi = fasebi[0];
decimal jamuriFasi = 0;
int minIndex = 0;
int maxIndex = 0;

for (int i = 0; i < menu.Length; i++)
{
    Console.WriteLine($"{i + 1}. {menu[i]} - {fasebi[i]} gel");

    if (fasebi[i] < minFasi)
    {
        minFasi = fasebi[i];
        minIndex = i;
    }

    if (fasebi[i] > maxFasi)
    {
        maxFasi = fasebi[i];
        maxIndex = i;
    }

    jamuriFasi += fasebi[i];
}

Console.WriteLine($"Iapisi qre: {menu[minIndex]} - {minFasi} gel");
Console.WriteLine($"Dzviri qre: {menu[maxIndex]} - {maxFasi} gel");
Console.WriteLine($"Jamuri fasi: {jamuriFasi} gel");
