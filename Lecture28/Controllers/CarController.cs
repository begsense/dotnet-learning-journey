using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lecture28.Models;
using System.Reflection.Metadata.Ecma335;

namespace Lecture28.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        [HttpGet("get-all-cars")]
        public List<Car> GetAllCars()
        {
            List<Car> list = new List<Car>()
            {
                new Car()
                {
                    Brand = "BMW",
                    Model = "740 iL"
                },
                new Car() {
                    Brand = "MERCEDES",
                    Model = "W210"
                }
            };
            return list;
        }

        [HttpGet("get-rare-cars")]
        public List<Car> GetAllRareCars()
        {
            List<Car> list = new List<Car>()
            {
                new Car()
                {
                    Brand = "Ishviati Mankana",
                    Model = "Ishviati iMankana"
                },
                new Car() {
                    Brand = "Ishviati Mankana",
                    Model = "Ishviati Mankana"
                }
            };
            return list;
        }
    }
}
