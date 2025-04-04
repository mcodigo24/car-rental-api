using car_rental_api.Domain.Entities;
using car_rental_api.Domain.Enums;
using car_rental_api.Domain.Repositories;
using car_rental_api.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace car_rental_api.Infrastructure.Repositories
{   
    public class CarsRepository : ICarsRepository
    {
        private readonly ApplicationDbContext _context;

        public CarsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Car?> GetCarWithRentalsAndServicesAsync(int carId)
        {
            return await _context.Cars
                .Include(c => c.Rentals.Where(r => r.RentalStatusId == (int)RentalStatusEnum.Confirmed)) 
                .Include(c => c.Services)
                .FirstOrDefaultAsync(c => c.Id == carId);
        }

        public async Task<bool> ExistsByIdAsync(int carId)
        {
            return await _context.Cars.AnyAsync(c => c.Id == carId);
        }
    }
}
