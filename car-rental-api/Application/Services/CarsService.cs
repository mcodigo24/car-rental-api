using car_rental_api.Application.Dtos;
using car_rental_api.Application.Interfaces;
using car_rental_api.Application.Mappers;
using car_rental_api.Domain.Entities;
using car_rental_api.Domain.Repositories;

namespace car_rental_api.Application.Services
{
    public class CarsService : ICarsService
    {
        private readonly ICarsRepository _carsRepository;
        private readonly IAvailabilityService _availabilityService;

        public CarsService(ICarsRepository carsRepository, IAvailabilityService availabilityService)
        {
            _carsRepository = carsRepository;
            _availabilityService = availabilityService;
        }

        public async Task<List<CarDto>> GetAvailableCarsAsync(DateTime startDate, DateTime endDate, string? filter)
        {
            var allCars = await _carsRepository.GetAllWithRentalsAndServicesAsync();

            var filteredCars = allCars
                .Where(car =>
                    string.IsNullOrEmpty(filter) ||
                    car.Type.Contains(filter, StringComparison.OrdinalIgnoreCase) ||
                    car.Model.Contains(filter, StringComparison.OrdinalIgnoreCase))
                .ToList();

            var availableCars = new List<Car>();

            foreach (var car in filteredCars)
            {
                if (await _availabilityService.IsCarAvailableAsync(car.Id, startDate, endDate))
                {
                    availableCars.Add(car);
                }
            }

            return [.. availableCars.Select(c => c.ToDto())];
        }
    }
}
