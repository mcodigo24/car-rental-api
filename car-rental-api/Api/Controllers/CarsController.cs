using car_rental_api.Application.Dtos;
using car_rental_api.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace car_rental_api.Api.Controllers
{
    [ApiController]
    [Route("api/cars")]
    public class CarsController : ControllerBase
    {
        private readonly ICarsService _carsService;

        public CarsController(ICarsService carsService) 
        { 
            _carsService = carsService;
        }

        /// <summary>
        /// Retrieves a list of available cars based on the selected date range and an optional type/model filter.
        /// </summary>
        /// <param name="startDate">Start date of the rental period.</param>
        /// <param name="endDate">End date of the rental period.</param>
        /// <param name="filter">Optional filter to search by car type or model.</param>
        /// <returns>A list of available cars that match the criteria.</returns>
        [HttpGet("available")]
        public async Task<ActionResult<List<CarDto>>> GetAvailableCars(
            [FromQuery] DateTime startDate,
            [FromQuery] DateTime endDate,
            [FromQuery] string? filter)
        {
            var cars = await _carsService.GetAvailableCarsAsync(startDate, endDate, filter);

            if (cars == null || cars.Count == 0)
                return NotFound("No available cars found for the selected dates and filter.");

            return Ok(cars);
        }
    }
}
