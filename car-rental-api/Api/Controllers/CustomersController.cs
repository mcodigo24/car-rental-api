using Microsoft.AspNetCore.Mvc;

namespace car_rental_api.Api.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        public CustomersController() { }

        [HttpGet]
        public string Get()
        {
            return "Get";
        }
    }
}
