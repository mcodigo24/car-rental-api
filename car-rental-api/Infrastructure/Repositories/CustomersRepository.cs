using car_rental_api.Domain.Repositories;
using car_rental_api.Infrastructure.Persistence.Database;

namespace car_rental_api.Infrastructure.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomersRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
