using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lecture35_FluentValidator.Data;
using Lecture35_FluentValidator.Models;
using Lecture35_FluentValidator.Requests.Users;
using AutoMapper;

namespace Lecture35_FluentValidator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Baza _baza;
        private readonly IMapper _mapper;

        public UserController(Baza baza, IMapper mapper)
        {
            _baza = baza;
            _mapper = mapper;
        }

        [HttpPost("create-user")]
        public IActionResult CreateUser(CreateUserRequest request)
        {
            var user = _mapper.Map<User>(request);

            _baza.Users.Add(user);
            _baza.SaveChanges();

            return Ok(user);
        }
    }
}
