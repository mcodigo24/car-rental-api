using car_rental_api.Domain.Repositories;
using car_rental_api.Infrastructure.Persistence.Database;

namespace car_rental_api.Infrastructure.Repositories
{
    public class RentalsRepository : IRentalsRepository
    {
        private readonly ApplicationDbContext _context;

        public RentalsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
