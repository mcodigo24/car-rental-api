using car_rental_api.Application.Dtos;
using car_rental_api.Application.Interfaces;
using car_rental_api.Application.Services;
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

        /// <summary>
        /// Registers a new customer if they do not already exist.
        /// If the customer already exists (matched by full name), returns the existing record.
        /// </summary>
        /// <param name="customerDto">The customer information to register.</param>
        /// <returns>The newly created or existing customer.</returns>
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

        /// <summary>
        /// Updates the information of an existing customer.
        /// </summary>
        /// <param name="customerDto">The updated customer data.</param>
        /// <returns>No content if the update is successful, or NotFound if the customer does not exist.</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomerDto customerDto)
        {
            await _customersService.UpdateAsync(customerDto);
            return NoContent();
        }
    }
}
