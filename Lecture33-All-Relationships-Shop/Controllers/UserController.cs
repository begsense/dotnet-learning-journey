using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lecture33_All_Relationships_Shop.Models;
using Lecture33_All_Relationships_Shop.Requests.Users;
using Lecture33_All_Relationships_Shop.Responses.Users;
using Lecture33_All_Relationships_Shop.Data;

namespace Lecture33_All_Relationships_Shop.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost("create-user")]
    public IActionResult CreateUser(CreateUserRequest request)
    {
        User user = new User
        {
            Email = request.Email,
            FullName = request.FullName,
            UserDetails = new UserDetails
            {
                Address = request.Address,
                City = request.City
            }
        };

        Baza baza = new Baza();

        baza.Users.Add(user);
        baza.SaveChanges();

        var response = new CreateUserResponse
        {
            Id = user.Id,
            Email = user.Email,
        };

        return Ok(response);
    }

    [HttpGet("get-users")]
    public IActionResult GetUsers()
    {
        Baza baza = new Baza();

        var users = baza.Users.ToList();

        return Ok(users);
    }
}
