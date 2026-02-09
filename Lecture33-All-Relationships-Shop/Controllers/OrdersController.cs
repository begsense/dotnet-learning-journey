using Lecture33_All_Relationships_Shop.Data;
using Lecture33_All_Relationships_Shop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lecture33_All_Relationships_Shop.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    [HttpPost("create-order")]
    public IActionResult CreateOrder(int userId, int productId, int quantity)
    {
        Baza baza = new Baza();

        var user = baza.Users.Find(userId);

        if (user == null)
            return NotFound("User not found");

        var product = baza.Products.Find(productId);

        if (product == null)
            return NotFound("Product not found");

        var order = new Order
        {
            UserId = userId,
            ProductId = productId,
            Quantity = quantity,
            OrderDate = DateTime.Now
        };

        baza.Orders.Add(order);
        baza.SaveChanges();

        return Ok(new
        {
            order.Id,
            order.OrderDate,
            order.Quantity,
            UserId = order.UserId,
            ProductId = order.ProductId
        });
    }

    [HttpGet("get-all-orders")]
    public IActionResult GetAllOrders()
    {
        Baza baza = new Baza();

        var orders = baza.Orders
            .Include(o => o.User)
            .Include(o => o.Product)
            .Select(o => new
            {
                o.Id,
                o.OrderDate,
                o.Quantity,
                User = new { o.User.Id, o.User.FullName, o.User.Email },
                Product = new { o.Product.Id, o.Product.Name, o.Product.Price },
                TotalPrice = o.Quantity * o.Product.Price
            })
            .ToList();

        return Ok(orders);
    }

    [HttpGet("user/{userId}/orders")]
    public IActionResult GetUserOrders(int userId)
    {
        Baza baza = new Baza();

        var user = baza.Users
            .Include(u => u.Orders)
                .ThenInclude(o => o.Product)
            .FirstOrDefault(u => u.Id == userId);

        if (user == null)
            return NotFound("User not found");

        var orders = user.Orders.Select(o => new
        {
            o.Id,
            o.OrderDate,
            o.Quantity,
            Product = new { o.Product.Id, o.Product.Name, o.Product.Price },
            TotalPrice = o.Quantity * o.Product.Price
        });

        return Ok(new
        {
            User = new { user.Id, user.FullName, user.Email },
            Orders = orders
        });
    }
}
