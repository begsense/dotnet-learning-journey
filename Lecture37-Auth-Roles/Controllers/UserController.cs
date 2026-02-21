using Lecture37_Auth_Roles.Data;
using Lecture37_Auth_Roles.Models;
using Lecture37_Auth_Roles.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace Lecture37_Auth_Roles.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly Baza _baza;

    public UserController(Baza baza)
    {
        _baza = baza;
    }

    [HttpPost("create-user")]
    public IActionResult CreateUser(CreateUserRequest req)
    {
        var userExists = _baza.Users.Any(u => u.UserName == req.UserName);

        if (userExists)
        {
            return BadRequest("User already exists.");
        }

        var user = new User
        {
            UserName = req.UserName,
            Password = BCrypt.Net.BCrypt.HashPassword(req.Password),
            Role = req.Role
        };

        _baza.Users.Add(user);
        _baza.SaveChanges();

        return Ok(user);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest req)
    {
        var user = _baza.Users.FirstOrDefault(u => u.UserName == req.UserName);

        if (user == null || !BCrypt.Net.BCrypt.Verify(req.Password, user.Password))
        {
            return Unauthorized("Invalid username or password.");
        }

        var isPasswordValid = BCrypt.Net.BCrypt.Verify(req.Password, user.Password);

        if (isPasswordValid)
        {
            var token = GenerateJwtToken(user);
            return Ok(new { Token = token });
        }
        else
        {
            return Unauthorized("Invalid username or password.");
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("get-users")]
    public IActionResult GetUsers()
    {
        var users = _baza.Users.ToList();

        return Ok(users);
    }

    private string GenerateJwtToken(User user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("6aGqzhHjVjdRx6hpitbzhy6NbZMWGLGXJ6pknM7ZiBZ"));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var token = new JwtSecurityToken(
            issuer: "CHVEN",
            audience: "ISINI",
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}