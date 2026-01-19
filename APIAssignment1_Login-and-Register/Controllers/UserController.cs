using Microsoft.AspNetCore.Mvc;
using APIAssignment1_Login_and_Register.Models;
using APIAssignment1_Login_and_Register.Data;
using APIAssignment1_Login_and_Register.Requests.Users;
using APIAssignment1_Login_and_Register.Services;

namespace APIAssignment1_Login_and_Register.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly Baza baza;
    private readonly PasswordService passwordService;

    public UserController(Baza parmBaza, PasswordService parmpasswordService)
    {
        baza = parmBaza;
        passwordService = parmpasswordService;
    }

    [HttpPost("register")]
    public User Register(AddUser request)
    {
        if (baza.Users.Any(u => u.Email == request.Email))
            return null;

        User user = new User()
        {
            UserName = request.UserName,
            Email = request.Email,
            Password = passwordService.Hash(request.Password)
        };

        baza.Users.Add(user);
        baza.SaveChanges();

        return user;
    }

    [HttpPost("login")]
    public User Login(LoginUser request)
    {
        var user = baza.Users
            .FirstOrDefault(u => u.Email == request.Email);

        if (user == null)
            return null;

        bool isValid = passwordService.Verify(
            request.Password,
            user.Password
        );

        if (!isValid)
            return null;

        return user;
    }
}
