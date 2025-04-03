using car_rental_api.Domain.Repositories;
using car_rental_api.Infrastructure.Persistence.Database;

namespace car_rental_api.Infrastructure.Repositories
{   
    public class CarsRepository : ICarsRepository
    {
        private readonly ApplicationDbContext _context;

        public CarsRepository(ApplicationDbContext context)
        {
            _context = context;
        }


    }
}
