using car_rental_api.Application.Dtos;
using car_rental_api.Application.Interfaces;
using car_rental_api.Application.Mappers;
using car_rental_api.Domain.Enums;
using car_rental_api.Domain.Repositories;

namespace car_rental_api.Application.Services
{
    public class RentalsService : IRentalsService
    {
        private readonly ICarsRepository _carsRepository;
        private readonly IRentalsRepository _rentalsRepository;
        private readonly ICustomersRepository _customersRepository;
        private readonly IAvailabilityService _availabilityService;

        public RentalsService(ICarsRepository carsRepository, IRentalsRepository rentalsRepository, ICustomersRepository customersRepository, IAvailabilityService availabilityService)
        {
            _carsRepository = carsRepository;
            _rentalsRepository = rentalsRepository;
            _customersRepository = customersRepository;
            _availabilityService = availabilityService;
        }

        public async Task<List<RentalResponseDto>> GetAllAsync()
        {
            var rentals = await _rentalsRepository.GetAllAsync();
            return rentals.ToListResponseDto();
        }

        public async Task<RentalDto> GetByIdAsync(int id)
        {
            var rental = await _rentalsRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Rental not found.");
            return rental.ToDto();
        }

        public async Task<RentalDto> AddAsync(RentalDto rentalDto)
        {
            await ValidateRental(rentalDto);

            var rental = rentalDto.ToEntity();
            rental.RentalStatusId = (int)RentalStatusEnum.Confirmed;
            var rentalId = await _rentalsRepository.AddAsync(rental);
            rentalDto.Id = rentalId;

            return rentalDto;
        }

        public async Task UpdateAsync(RentalDto rentalDto)
        {
            var rental = await _rentalsRepository.GetByIdAsync(rentalDto.Id) ?? throw new KeyNotFoundException("Rental not found.");

            await ValidateRental(rentalDto, isUpdate: true);

            await _rentalsRepository.UpdateAsync(rental.ToUpdateEntity(rentalDto));
        }

        public async Task CancelAsync(int id)
        {
            await _rentalsRepository.CancelAsync(id);
        }

        #region Private methods        

        private async Task ValidateRental(RentalDto rentalDto, bool isUpdate = false)
        {
            if (!await _carsRepository.ExistsByIdAsync(rentalDto.CarId))
                throw new KeyNotFoundException("Car not found.");

            if (!await _customersRepository.ExistsByIdAsync(rentalDto.CustomerId))
                throw new KeyNotFoundException("Customer not found.");

            if (!await _availabilityService.IsCarAvailableAsync(rentalDto.CarId, rentalDto.StartDate, rentalDto.EndDate, isUpdate ? rentalDto.Id : null))
                throw new ArgumentException("The car is not available for the selected dates.");
        }

        #endregion
    }
}
