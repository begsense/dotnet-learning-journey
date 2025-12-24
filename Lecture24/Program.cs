using Lecture24.Models;
using Lecture24.Data;

Base baza = new Base();

//Product product = new Product()
//{
//    Name = "iPhone 17",
//    Quantity = 3
//};

//baza.Products.Add(product);
//baza.SaveChanges();

var allProducts = baza.Products.ToList();

foreach (var product in allProducts)
{
    Console.WriteLine(product.Name);
}