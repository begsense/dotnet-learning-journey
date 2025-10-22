using Lecture14.Models;

User begi = new User();

begi.FullName = "Begi Kopaliani";
//begi.isAdmin = true;
//begi.balance += 500;

begi.Deposit();

Console.WriteLine($"User: {begi.FullName}, Balance: {begi.Balance}, {begi.IsAdmin}");

if (begi.IsAdmin)
{
    Console.WriteLine("Super Secret Data");
}


Hero hero = new Hero();
hero.SetPrice(29.99, begi);
