using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lecture33_All_Relationships_Shop.Models;
using Lecture33_All_Relationships_Shop.Requests.Products;
using Lecture33_All_Relationships_Shop.Responses.Products;
using Lecture33_All_Relationships_Shop.Data;
using Microsoft.EntityFrameworkCore;

namespace Lecture33_All_Relationships_Shop.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    [HttpPost("create-product")]
    public IActionResult CreateProduct(CreateProductRequest request)
    {
        var product = new Product
        {
            Name = request.Name,
            Price = request.Price,
        };

        Baza baza = new Baza();

        baza.Products.Add(product);
        baza.SaveChanges();

        var response = new CreateProductResponse
        {
            Id = product.Id
        };

        return Ok(response);
    }

    [HttpPost("create-category")]
    public IActionResult CreateCategory(string name)
    {
        Baza baza = new Baza();

        var category = new Category { Name = name };

        baza.Categories.Add(category);
        baza.SaveChanges();

        return Ok(new { category.Id, category.Name });
    }

    [HttpPost("add-product-to-category")]
    public IActionResult AddProductToCategory(int productId, int categoryId)
    {
        Baza baza = new Baza();

        var product = baza.Products
            .Include(p => p.Categories)
            .FirstOrDefault(p => p.Id == productId);

        if (product == null)
        {
            return NotFound("Product not found");
        }

        var category = baza.Categories.Find(categoryId);

        if (category == null)
        {
            return NotFound("Category not found");
        }

        if (product.Categories.Any(c => c.Id == categoryId))
        {
            return BadRequest("Product already in this category");
        }

        product.Categories.Add(category);
        baza.SaveChanges();

        return Ok(new
        {
            product.Id,
            product.Name,
            Categories = product.Categories.Select(c => new { c.Id, c.Name })
        });
    }

    [HttpGet("get-products")]
    public IActionResult GetProducts()
    {
        Baza baza = new Baza();

        var products = baza.Products
            .Include(p => p.Categories)
            .Select(p => new
            {
                p.Id,
                p.Name,
                p.Price,
                Categories = p.Categories.Select(c => new { c.Id, c.Name })
            })
            .ToList();

        return Ok(products);
    }

    [HttpGet("get-categories")]
    public IActionResult GetCategories()
    {
        Baza baza = new Baza();

        var categories = baza.Categories
            .Include(c => c.Products)
            .Select(c => new
            {
                c.Id,
                c.Name,
                Products = c.Products.Select(p => new { p.Id, p.Name, p.Price })
            })
            .ToList();

        return Ok(categories);
    }

}
