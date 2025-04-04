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

        [HttpGet]
        public async Task<ActionResult<List<RentalDto>>> GetRentals()
        {
            var rentals = await _rentalService.GetAllAsync();

            if (rentals == null || rentals.Count == 0)
                throw new KeyNotFoundException("No rentals found.");

            return Ok(rentals);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RentalDto>> GetRental([FromRoute] int id)
        {
            var rental = await _rentalService.GetByIdAsync(id);
            return Ok(rental);
        }

        [HttpPost]
        public async Task<ActionResult<RentalDto>> RegisterRental([FromBody] RentalDto rentalDto)
        {
            var newRental = await _rentalService.AddAsync(rentalDto);
            return CreatedAtAction(nameof(GetRental), new { id = newRental.Id }, newRental);
        }

        [HttpPut]
        public string UpdateRental([FromBody] RentalDto rentalDto)
        {
            return "Post";
        }

        [HttpDelete]
        public string DeleteRental([FromQuery] int rentalId)
        {
            return "Delete";
        }
    }
}
