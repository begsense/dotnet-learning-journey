using APIAssignment2_NeoBank.Data;
using APIAssignment2_NeoBank.Responses.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIAssignment2_NeoBank.Controllers;

[Route("api/user")]
[ApiController]
public class AdminController : ControllerBase
{
    private readonly Baza baza;

    public AdminController(Baza baza)
    {
        this.baza = baza;
    }

    [HttpGet("risk-report/{id}")]
    public IActionResult ReadUserProfile(int id)
    {
        var user = baza.UserProfiles
            .Include(u => u.FinancialProfile)
            .Include(u => u.PassportDetails)
            .FirstOrDefault(u => u.Id == id);

        if (user == null)
        {
            return NotFound(new { Message = "User not found." });
        }

        var response = new ReadUserRiskReportResponse
        {
            Id = user.Id,
            MonthlyIncome = user.FinancialProfile.MonthlyIncome,
            SourceOfFunds = user.FinancialProfile.SourceOfFunds,
            RiskScore = user.FinancialProfile.RiskScore,
            PersonalNumber = user.PassportDetails.PersonalNumber,
            DocumentNumber = user.PassportDetails.DocumentNumber,
            ExpiryDate = user.PassportDetails.ExpiryDate,
            ImageStoragePath = user.PassportDetails.ImageStoragePath
        };

        return Ok(response);
    }
}