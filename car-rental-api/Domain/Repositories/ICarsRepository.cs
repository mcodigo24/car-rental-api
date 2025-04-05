using car_rental_api.Domain.Entities;

namespace car_rental_api.Domain.Repositories
{
    public interface ICarsRepository
    {
        Task<Car?> GetCarWithRentalsAndServicesAsync(int carId);
        Task<bool> ExistsByIdAsync(int carId);
        Task<List<Car>> GetAllWithRentalsAndServicesAsync();
    }
}
