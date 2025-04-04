using car_rental_api.Application.Dtos;
using car_rental_api.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace car_rental_api.Api.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersService _customersService;

        public CustomersController(ICustomersService customersService)
        {
            _customersService = customersService;
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDto>> RegisterCustomer([FromBody] CustomerDto customerDto)
        {
            var newCustomer = await _customersService.AddIfNotExistsAsync(customerDto);

            if (newCustomer == null)
            {
                var existingCustomer = await _customersService.GetByFullNameAsync(customerDto.FullName);
                return Ok(existingCustomer);
            }

            return Ok(newCustomer);
        }
    }
}
