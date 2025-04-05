using car_rental_api.Application.Dtos;

namespace car_rental_api.Application.Interfaces
{
    public interface IRentalsService
    {       
        Task<List<RentalDto>> GetAllAsync();
        Task<RentalDto> GetByIdAsync(int id);
        Task<RentalDto> AddAsync(RentalDto rentalDto);
        Task UpdateAsync(RentalDto rentalDto);
        Task CancelAsync(int id);
    }
}
