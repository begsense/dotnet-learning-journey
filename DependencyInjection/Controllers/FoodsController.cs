using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DependencyInjection.Services.Abstractions;
using DependencyInjection.Services.Implementations;
using DependencyInjection.Requests;

namespace DependencyInjection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly IFoodService _foodService;

        public FoodsController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpPost]
        public IActionResult AddFood(AddFoodRequest request)
        {
            var response = _foodService.AddFood(request);

            return Ok(response);
        }
    }
}
