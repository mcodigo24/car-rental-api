using car_rental_api.Application.Dtos;

namespace car_rental_api.Application.Interfaces
{
    public interface ICustomersService
    {
        Task AddAsync(CustomerDto customerDto);
    }
}
