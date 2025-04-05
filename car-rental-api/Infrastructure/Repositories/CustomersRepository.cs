using car_rental_api.Domain.Entities;
using car_rental_api.Domain.Repositories;
using car_rental_api.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace car_rental_api.Infrastructure.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomersRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return customer.Id;
        }

        public async Task<bool> ExistsByFullNameAsync(string fullName)
        {
            return await _context.Customers.AnyAsync(c => c.FullName.ToUpper() == fullName.ToUpper());
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            return await _context.Customers.AnyAsync(c => c.Id == id);
        }

        public async Task<Customer?> GetByFullNameAsync(string fullName)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.FullName.ToUpper() == fullName.ToUpper());
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }
    }
}
