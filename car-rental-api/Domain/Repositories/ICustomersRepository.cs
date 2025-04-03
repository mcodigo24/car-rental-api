using car_rental_api.Domain.Entities;

namespace car_rental_api.Domain.Repositories
{
    public interface ICustomersRepository
    {
        Task AddAsync(Customer customer);
        Task<bool> ExistCustomer(string fullName);
    }
}
