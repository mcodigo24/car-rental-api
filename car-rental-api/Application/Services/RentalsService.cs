using car_rental_api.Application.Dtos;
using car_rental_api.Application.Interfaces;
using car_rental_api.Application.Mappers;
using car_rental_api.Domain.Entities;
using car_rental_api.Domain.Enums;
using car_rental_api.Domain.Repositories;

namespace car_rental_api.Application.Services
{
    public class RentalsService : IRentalsService
    {
        private readonly ICarsRepository _carsRepository;
        private readonly IRentalsRepository _rentalsRepository;
        private readonly ICustomersRepository _customersRepository;

        public RentalsService(ICarsRepository carsRepository, IRentalsRepository rentalsRepository, ICustomersRepository customersRepository)
        {
            _carsRepository = carsRepository;
            _rentalsRepository = rentalsRepository;
            _customersRepository = customersRepository;
        }

        public async Task<List<RentalDto>> GetAllAsync()
        {
            var rentals = await _rentalsRepository.GetAllAsync();
            return rentals.ToListDto();
        }

        public async Task<RentalDto> GetByIdAsync(int id)
        {
            var rental = await _rentalsRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Rental not found.");
            return rental.ToDto();
        }

        public async Task<RentalDto> AddAsync(RentalDto rentalDto)
        {
            if (!await _carsRepository.ExistsByIdAsync(rentalDto.CarId))
                throw new KeyNotFoundException("Car not found.");

            if (!await _customersRepository.ExistsByIdAsync(rentalDto.CustomerId))
                throw new KeyNotFoundException("Customer not found.");

            if (!await IsCarAvailableAsync(rentalDto.CarId, rentalDto.StartDate, rentalDto.EndDate))
                throw new ArgumentException("The car is not available for the selected dates.");

            var rental = rentalDto.ToEntity();
            rental.RentalStatusId = (int)RentalStatusEnum.Confirmed;
            var rentalId = await _rentalsRepository.AddAsync(rental);
            rentalDto.Id = rentalId;

            return rentalDto;
        }

        #region Private methods

        private async Task<bool> IsCarAvailableAsync(int carId, DateTime startDate, DateTime endDate)
        {
            var car = await _carsRepository.GetCarWithRentalsAndServicesAsync(carId);

            if (car == null) return false;

            if (IsRented(car, startDate, endDate)) return false;

            if (HasRecentRental(car, startDate)) return false;

            if (HasMaintenanceConflict(car, startDate, endDate)) return false;

            return true;
        }

        private static bool IsRented(Car car, DateTime startDate, DateTime endDate)
        {
            return car.Rentals.Any(rental =>
                 (startDate >= rental.StartDate && startDate <= rental.EndDate) ||
                 (endDate >= rental.StartDate && endDate <= rental.EndDate) ||
                 (startDate <= rental.StartDate && endDate >= rental.EndDate)
            );
        }

        private static bool HasRecentRental(Car car, DateTime startDate)
        {
            return car.Rentals.Any(rental => rental.EndDate.AddDays(1) == startDate);
        }

        private static bool HasMaintenanceConflict(Car car, DateTime startDate, DateTime endDate)
        {
            bool hasMaintenanceConflict = false;

            DateTime? lastServiceDate = car.Services.OrderByDescending(s => s.Date).FirstOrDefault()?.Date;

            if (lastServiceDate.HasValue)
            {
                DateTime nextServiceDate = lastServiceDate.Value;

                while (nextServiceDate < endDate)
                {
                    nextServiceDate = nextServiceDate.AddMonths(2);
                    DateTime serviceEndDate = nextServiceDate.AddDays(1);

                    bool maintenanceConflict =
                        (startDate >= nextServiceDate && startDate <= serviceEndDate) ||
                        (endDate >= nextServiceDate && endDate <= serviceEndDate) ||
                        (startDate <= nextServiceDate && endDate >= serviceEndDate);

                    if (maintenanceConflict) hasMaintenanceConflict = true;
                }
            }

            return hasMaintenanceConflict;
        }

        #endregion
    }
}
