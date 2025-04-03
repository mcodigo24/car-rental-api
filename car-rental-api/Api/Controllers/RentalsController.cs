using Microsoft.AspNetCore.Mvc;

namespace car_rental_api.Api.Controllers
{
    [ApiController]
    [Route("api/rentals")]
    public class RentalsController : ControllerBase
    {
        public RentalsController() { }

        [HttpGet]
        public string Get()
        {
            return "Get";
        }
    }
}
