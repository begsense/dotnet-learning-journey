using Lecture29_One_To_One.Data;
using Lecture29_One_To_One.Models;
using Lecture29_One_To_One.Request.User;
using Lecture29_One_To_One.Responses.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lecture29_One_To_One.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost("create-user")]
    public ActionResult CreateUser(CreateUser req)
    {
        var user = new User()
        {
            FullName = req.FullName,
            UserDetails = new UserDetails()
            {
                PhoneNumber = req.PhoneNumber,
                WorkPlace = req.WorkPlace
            }
        };

        Baza baza = new Baza();

        baza.Users.Add(user);
        baza.SaveChanges();

        var response = new UserResponse() {
            Id = user.Id
        };

        return Ok(response);
    }

    [HttpGet("get-all-users")]
    public ActionResult GetAllUser()
    {
        Baza baza = new Baza();
        var allUsers = baza.Users.Include(u => u.UserDetails)
       .Select(u => new UserInfoResponse
       {
           Id = u.Id,
           FullName = u.FullName,
           PhoneNumber = u.UserDetails.PhoneNumber,
           WorkPlace = u.UserDetails.WorkPlace,
       });

    return Ok(allUsers);
    }
}
