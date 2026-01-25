using APIAssignment2_NeoBank.Data;
using APIAssignment2_NeoBank.Responses.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIAssignment2_NeoBank.Controllers;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly Baza baza;

    public UserController(Baza baza)
    {
        this.baza = baza;
    }

    [HttpGet("full-profile/{id}")]
    public IActionResult ReadUserProfile(int id)
    {
        var user = baza.UserProfiles
            .Include(u => u.UserAccount)
            .Include(u => u.AppSettings)
            .FirstOrDefault(u => u.Id == id);

        if (user == null)
        {
            return NotFound(new { Message = "User not found." });
        }

        var response = new ReadUserProfileResponse
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            DateOfBirth = user.DateOfBirth,
            PhoneNumber = user.PhoneNumber,

            Email = user.UserAccount.Email,
            RegistrationDate = user.UserAccount.RegistrationDate,
            IsActive = user.UserAccount.IsActive,

            Theme = user.AppSettings?.Theme ?? false,
            Language = user.AppSettings?.Language ?? "EN",
            PushNotificationsEnabled = user.AppSettings?.PushNotificationsEnabled ?? true
        };

        return Ok(response);
    }
}