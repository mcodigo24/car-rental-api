using car_rental_api.Application.Dtos;
using car_rental_api.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace car_rental_api.Api.Controllers
{
    [ApiController]
    [Route("api/rentals")]
    public class RentalsController : ControllerBase
    {
        private readonly IRentalsService _rentalService;

        public RentalsController(IRentalsService rentalService)
        {
            _rentalService = rentalService;
        }

        /// <summary>
        /// Retrieves a list of all registered rentals.
        /// </summary>
        /// <returns>A list of rental records.</returns>
        /// <exception cref="KeyNotFoundException"></exception>
        [HttpGet]
        public async Task<ActionResult<List<RentalResponseDto>>> GetRentals()
        {
            var rentals = await _rentalService.GetAllAsync();

            if (rentals == null || rentals.Count == 0)
                throw new KeyNotFoundException("No rentals found.");

            return Ok(rentals);
        }

        /// <summary>
        /// Retrieves a specific rental by its Id.
        /// </summary>
        /// <param name="id">The Id of the rental to retrieve.</param>
        /// <returns>The rental details if found.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<RentalDto>> GetRental([FromRoute] int id)
        {
            var rental = await _rentalService.GetByIdAsync(id);
            return Ok(rental);
        }

        /// <summary>
        /// Registers a new rental with the specified details.
        /// </summary>
        /// <param name="rentalDto">The rental information to register.</param>
        /// <returns>The newly created rental, including its assigned Id.</returns>
        [HttpPost]
        public async Task<ActionResult<RentalDto>> RegisterRental([FromBody] RentalDto rentalDto)
        {
            var newRental = await _rentalService.AddAsync(rentalDto);
            return CreatedAtAction(nameof(GetRental), new { id = newRental.Id }, newRental);
        }

        /// <summary>
        /// Updates the details of an existing rental.
        /// </summary>
        /// <param name="rentalDto">The updated rental information.</param>
        /// <returns>No content if the update is successful, or NotFound if the rental does not exist.</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateRental([FromBody] RentalDto rentalDto)
        {
            await _rentalService.UpdateAsync(rentalDto);
            return NoContent();
        }

        /// <summary>
        /// Cancels an existing rental by updating its status.
        /// </summary>
        /// <param name="id">The ID of the rental to cancel.</param>
        /// <returns>No content if successful, or NotFound if the rental does not exist.</returns>
        [HttpPatch("{id}/cancel")]
        public async Task<IActionResult> CancelRental([FromRoute] int id)
        {
            await _rentalService.CancelAsync(id);
            return NoContent();
        }
    }
}
