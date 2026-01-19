using Microsoft.AspNetCore.Mvc;
using APIAssignment1_Login_and_Register.Models;
using APIAssignment1_Login_and_Register.Data;
using APIAssignment1_Login_and_Register.Requests.Products;

namespace APIAssignment1_Login_and_Register.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController
{
    private readonly Baza baza;
    public ProductController(Baza parmBaza)
    {
        baza = parmBaza;
    }

    [HttpPost("add-product")]
    public Product AddProduct(AddProduct request)
    {
        Product product = new Product()
        {
            ProductName = request.ProductName,
            ProductDescription = request.ProductDescription,
            ProductCategory = request.ProductCategory,
            Price = request.Price,
            Quantity = request.Quantity
        };

        baza.Products.Add(product);
        baza.SaveChanges();

        return product;
    }

    [HttpGet("view-all")]
    public List<Product> GetAll()
    {
        var products = baza.Products.ToList();
        return products;
    }

    [HttpGet("sort")]
    public List<Product> Sort(string sortBy = "name", bool desc = false)
    {
        IQueryable<Product> query = baza.Products;

        if (sortBy.ToLower() == "name")
        {
            query = desc
                ? query.OrderByDescending(p => p.ProductName)
                : query.OrderBy(p => p.ProductName);
        }
        else
        {
            query = query.OrderBy(p => p.ProductName);
        }

        return query.ToList();
    }
}
