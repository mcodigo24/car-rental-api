using car_rental_api.Domain.Entities;

namespace car_rental_api.Domain.Repositories
{
    public interface ICustomersRepository
    {
        Task<int> AddAsync(Customer customer);
        Task<bool> ExistsByFullNameAsync(string fullName);
        Task<bool> ExistsByIdAsync(int id);
        Task<Customer?> GetByFullNameAsync(string fullName);
    }
}
