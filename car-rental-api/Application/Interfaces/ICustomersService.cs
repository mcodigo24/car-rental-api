using car_rental_api.Application.Dtos;

namespace car_rental_api.Application.Interfaces
{
    public interface ICustomersService
    {
        Task<CustomerDto?> AddIfNotExistsAsync(CustomerDto customerDto);
        Task<CustomerDto> GetByFullNameAsync(string fullName);
    }
}
