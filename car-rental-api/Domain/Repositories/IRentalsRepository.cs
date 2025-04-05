using car_rental_api.Domain.Entities;

namespace car_rental_api.Domain.Repositories
{
    public interface IRentalsRepository
    {
        Task<Rental?> GetByIdAsync(int rentalId);
        Task<int> AddAsync(Rental rental);
        Task UpdateAsync(Rental rental);
        Task CancelAsync(int rentalId);
        Task<List<Rental>> GetAllAsync();
    }
}
