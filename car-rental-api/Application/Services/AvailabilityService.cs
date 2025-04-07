using car_rental_api.Application.Interfaces;
using car_rental_api.Domain.Entities;
using car_rental_api.Domain.Repositories;

namespace car_rental_api.Application.Services
{
    public class AvailabilityService : IAvailabilityService
    {
        private readonly ICarsRepository _carsRepository;

        public AvailabilityService(ICarsRepository carsRepository)
        {
            _carsRepository = carsRepository;
        }

        public async Task<bool> IsCarAvailableAsync(int carId, DateTime startDate, DateTime endDate, int? rentalId = null)
        {
            var car = await _carsRepository.GetCarWithRentalsAndServicesAsync(carId);

            if (car == null) return false;

            var rentals = car.Rentals;

            if (rentalId != null)
                rentals = [.. rentals.Where(r => r.Id != rentalId)];

            if (IsRented(rentals, startDate, endDate)) return false;

            if (HasRecentRental(rentals, startDate)) return false;

            if (HasMaintenanceConflict(car, startDate, endDate)) return false;

            return true;
        }

        #region Private methods

        private static bool IsRented(List<Rental> rentals, DateTime startDate, DateTime endDate)
        {
            return rentals.Any(rental =>
                 (startDate >= rental.StartDate && startDate <= rental.EndDate) ||
                 (endDate >= rental.StartDate && endDate <= rental.EndDate) ||
                 (startDate <= rental.StartDate && endDate >= rental.EndDate)
            );
        }

        private static bool HasRecentRental(List<Rental> rentals, DateTime startDate)
        {
            return rentals.Any(rental => rental.EndDate.AddDays(1) == startDate);
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
