using Lecture30_CRUD.Data;
using Lecture30_CRUD.Requests.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lecture30_CRUD.Models;
using Lecture30_CRUD.Responses.Products;

namespace Lecture30_CRUD.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    [HttpPost("create-product")]
    public ActionResult CreateProduct(CreateProduct req)
    {
        Baza baza = new Baza();
        Product product = new Product()
        {
            Title = req.Title,
            Price = req.Price
        };
        //Check if product exists
        var alreadyExists = baza.Products.Any(p => p.Title == req.Title);

        if (alreadyExists)
        {
            return BadRequest( new { Message = "Product with this title already exists." });
        }
        else
        {
            baza.Products.Add(product);
            baza.SaveChanges();

            var response = new CreateProductResponse() { Id = product.Id }; 
            return Ok(response);
        }
    }

    [HttpGet("get-all-products")]
    public ActionResult GetAllProducts()
    {
        Baza baza = new Baza();
        var products = baza.Products.ToList();
        if (products.Count == 0)
        {
            return NotFound(new { Message = "No products found." });
        }
        return Ok(products);
    }

    [HttpDelete("delete-product")]
    public ActionResult DeleteProduct(int id)
    {
        Baza baza = new Baza();

        var product = baza.Products.Find(id);

        if (product == null)
        {
            return NotFound(new { Message = "Product not found." });
        }

        baza.Products.Remove(product);
        baza.SaveChanges();
        
        var response = new DeleteProductResponse() { Id = id };

        return Ok(response);
    }

    [HttpPatch("edit-title")]
    public ActionResult EditTitle(PatchProductTitle req)
    {
        Baza baza = new Baza();

        var product = baza.Products.Find(req.Id);

        if (product == null)
        {
            return NotFound(new { Message = "Product not found." });
        }
        else
        {
            product.Title = req.NewTitle;

            baza.Products.Update(product);

            baza.SaveChanges();

            var response = new PatchProductResponse() { Id = req.Id };

            return Ok(response);
        }
    }

    [HttpPut("edit-product")]
    public ActionResult EditProduct(EditProduct req)
    {
        Baza baza = new Baza();

        var product = baza.Products.Find(req.Id);

        if (product == null)
        {
            return NotFound(new { Message = "Product not found." });
        }
        else
        {
            product.Title = req.NewTitle;

            product.Price = req.NewPrice;

            baza.Products.Update(product);

            baza.SaveChanges();

            var response = new PutProductResponse() { Id = req.Id };

            return Ok(response);
        }
    }
}
