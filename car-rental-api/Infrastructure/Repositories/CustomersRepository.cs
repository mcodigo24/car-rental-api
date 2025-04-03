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

        public async Task AddAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();            
        }

        public async Task<bool> ExistCustomer(string fullName)
        {
            return await _context.Customers.AnyAsync(c => c.FullName.Equals(fullName, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
