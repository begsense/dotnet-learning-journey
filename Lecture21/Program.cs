using Lecture21.Models;

Shape shape1 = new Shape();
Shape shape2 = new Rectangle();
Shape shape3 = new Circle();

shape1.CalculateArea();
shape2.CalculateArea();
shape3.CalculateArea();

Console.WriteLine("-----------------------");

BusinessAccount businessAccount = new BusinessAccount();
CasualAccount casualAccount = new CasualAccount();

businessAccount.Withdraw();
casualAccount.Withdraw();