using Microsoft.AspNetCore.Mvc;

namespace car_rental_api.Api.Controllers
{
    [ApiController]
    [Route("api/cars")]
    public class CarsController : ControllerBase
    {
        public CarsController() { }

        [HttpGet]
        public string Get()
        {
            return "Get";
        }
    }
}
