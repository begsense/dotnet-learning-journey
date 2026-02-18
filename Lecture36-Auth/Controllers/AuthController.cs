using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lecture36_Auth.Data;
using Lecture36_Auth.Requests.Users;
using Lecture36_Auth.Models;
using BCrypt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;

using System.IdentityModel.Tokens.Jwt;


namespace Lecture36_Auth.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly Baza _baza;

    public AuthController(Baza baza)
    {
        _baza = baza;
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterUser request)
    {
        if (_baza.Users.Any(u => u.Email == request.Email))
        {
            return BadRequest("User with this email already exists.");
        }
        var user = new User
        {
            Email = request.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(request.Password)
        };

        _baza.Users.Add(user);
        _baza.SaveChanges();

        return Ok("User registered successfully.");
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] RegisterUser request)
    {
        var user = _baza.Users.FirstOrDefault(u => u.Email == request.Email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
        {
            return Unauthorized("Invalid email or password.");
        }

        var token = GenerateJwtToken(user);

        return Ok(new {Token = token});
    }

    private string GenerateJwtToken(User user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_secret_key_here"));
        
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email)
        };

        var token = new JwtSecurityToken(
            issuer: "your_issuer_here",
            audience: "your_audience_here",
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
