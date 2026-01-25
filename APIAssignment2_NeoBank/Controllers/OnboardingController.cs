using Microsoft.AspNetCore.Mvc;
using APIAssignment2_NeoBank.Models;
using APIAssignment2_NeoBank.Requests.Users;
using APIAssignment2_NeoBank.Data;
using APIAssignment2_NeoBank.Services;
using APIAssignment2_NeoBank.Responses.Users;
using Microsoft.EntityFrameworkCore;

namespace APIAssignment2_NeoBank.Controllers
{
    [Route("api/onboarding")]
    [ApiController]
    public class OnboardingController : ControllerBase
    {
        private readonly Baza baza;
        private readonly PasswordService passwordService;

        public OnboardingController(Baza baza, PasswordService passwordService)
        {
            this.baza = baza;
            this.passwordService = passwordService;
        }

        [HttpPost("start")]
        public IActionResult StartOnboarding(CreateUser req)
        {
            if (baza.UserProfiles.Any(u => u.UserAccount.Email == req.Email))
            {
                return BadRequest(new { Message = "Email already in use." });
            }

            var newUser = new UserProfile()
            {
                FirstName = req.FirstName,
                LastName = req.LastName,
                DateOfBirth = req.DateOfBirth,
                PhoneNumber = req.PhoneNumber,
                UserAccount = new UserAccount()
                {
                    Email = req.Email,
                    PasswordHash = passwordService.Hash(req.PasswordHash),
                    RegistrationDate = req.RegistrationDate,
                    IsActive = req.IsActive
                }
            };

            baza.UserProfiles.Add(newUser);
            baza.SaveChanges();

            var response = new CreateUserResponse
            {
                Id = newUser.Id,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName
            };

            return Ok(response);
        }

        [HttpPut("kyc/{userId}")]
        public IActionResult UpdateKYC(int userId, UpdateUserPassportDetails req)
        {
            var user = baza.UserProfiles
                .Include(u => u.PassportDetails)
                .FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return NotFound(new { Message = "User not found." });
            }

            if (user.PassportDetails != null)
            {
                return Conflict(new { Message = "Passport details already exist." });
            }

            var passportDetails = new PassportDetails()
            {
                PersonalNumber = req.PersonalNumber,
                DocumentNumber = req.DocumentNumber,
                ImageStoragePath = req.ImageStoragePath,
                ExpiryDate = req.ExpiryDate,
                UserProfileId = user.Id
            };

            baza.PassportDetails.Add(passportDetails);
            baza.SaveChanges();

            var response = new UpdateUserPassportDetailsResponse
            {
                Id = passportDetails.Id,
                PersonalNumber = passportDetails.PersonalNumber,
                DocumentNumber = passportDetails.DocumentNumber,
                ExpiryDate = passportDetails.ExpiryDate
            };

            return Ok(response);
        }

        [HttpPut("financial/{userId}")]
        public IActionResult UpdateFinancial(int userId, UpdateFinancialProfile req)
        {
            var user = baza.UserProfiles
                .Include(u => u.FinancialProfile)
                .FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return NotFound(new { Message = "User not found." });
            }

            if (user.FinancialProfile != null)
            {
                return Conflict(new { Message = "Financial profile already exists." });
            }

            var financialProfile = new FinancialProfile()
            {
                MonthlyIncome = req.MonthlyIncome,
                SourceOfFunds = req.SourceOfFunds,
                RiskScore = req.RiskScore,
                UserProfileId = user.Id
            };


            baza.FinancialProfiles.Add(financialProfile);
            baza.SaveChanges();

            var response = new UpdateFinancialProfileResponse
            {
                Id = financialProfile.Id,
                MonthlyIncome = req.MonthlyIncome,
                SourceOfFunds = req.SourceOfFunds,
                RiskScore = req.RiskScore
            };

            return Ok(response);
        }
    }
}
