using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lecture31_One_To_Many.Models;
using Lecture31_One_To_Many.Requests.Users;
using Lecture31_One_To_Many.Requests.BankAccount;
using Lecture31_One_To_Many.Data;
using Lecture31_One_To_Many.Responses.Users;
using Lecture31_One_To_Many.Responses.BankAccounts;
using Microsoft.EntityFrameworkCore;

namespace Lecture31_One_To_Many.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost("create-user")]
        public IActionResult CreateUser(AddUserRequest req)
        {
            var user = new User()
            {
                FirstName = req.FirstName,
                Email = req.Email
            };

            Baza baza = new Baza();

            baza.Users.Add(user);
            baza.SaveChanges();

            var response = new AddUserResponses()
            {
                Id = user.Id
            };

            return Ok(response);
        }

        [HttpPost("create-account-number")]
        public IActionResult CreateAccountNumber(CreateBankAccountRequest req)
        {
            var bankAccount = new BankAccount()
            {
                IBAN = req.IBAN,
                CurrencyType = req.CurrencyType,
                IsActive = true,
                UserId = req.UserId
            };
            Baza baza = new Baza();

            baza.BankAccounts.Add(bankAccount);
            baza.SaveChanges();

            var response = new AddBankAccountResponse()
            {
                Id = bankAccount.Id
            };
            return Ok(response);
        }

        [HttpGet("get-user-full")]
        public IActionResult GetUserFull(int userId)
        {
            Baza baza = new Baza();

            var users = baza.Users

                            .Include(u => u.BankAccounts)

                            .Select(u =>

                              new GetFullUserResponse

                              {

                                  FirstName = u.FirstName,

                                  BankAccounts = u.BankAccounts.Select(b => new BankAccountResponse { Amount = b.Amount, CurrencyType = b.CurrencyType, IBAN = b.IBAN }).ToList()

                              }).ToList();


            if (users == null)
            {
                return NotFound("User not found");
            }
            return Ok(users);
        }
    }
}
