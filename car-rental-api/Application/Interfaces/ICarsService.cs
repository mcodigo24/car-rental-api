using car_rental_api.Application.Dtos;

namespace car_rental_api.Application.Interfaces
{
    public interface ICarsService
    {
        Task<List<CarDto>> GetAvailableCarsAsync(DateTime startDate, DateTime endDate, string? filter);
        Task<MostRentedDto> GetMostRentedTypeAsync();
    }
}
