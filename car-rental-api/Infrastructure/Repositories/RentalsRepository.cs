using car_rental_api.Domain.Entities;
using car_rental_api.Domain.Enums;
using car_rental_api.Domain.Repositories;
using car_rental_api.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace car_rental_api.Infrastructure.Repositories
{
    public class RentalsRepository : IRentalsRepository
    {
        private readonly ApplicationDbContext _context;

        public RentalsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Rental?> GetByIdAsync(int rentalId)
        {
            return await GetById(rentalId);
        }

        public async Task<int> AddAsync(Rental rental)
        {
            _context.Rentals.Add(rental);
            await _context.SaveChangesAsync();

            return rental.Id;
        }

        public async Task UpdateAsync(Rental rental)
        {
            _context.Rentals.Update(rental);
            await _context.SaveChangesAsync();
        }

        public async Task CancelAsync(int rentalId)
        {
            var rental = await GetById(rentalId) ?? throw new KeyNotFoundException("Rental not found.");

            rental.RentalStatusId = (int)RentalStatusEnum.Cancelled;
            _context.Rentals.Update(rental);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Rental>> GetAllAsync()
        {
            return await _context.Rentals
                                 .Include(c => c.Customer)
                                 .Include(c => c.Car)
                                 .Where(r => r.RentalStatusId == (int)RentalStatusEnum.Confirmed).ToListAsync();
        }

        #region Private methods

        private async Task<Rental?> GetById(int rentalId)
        {
            return await _context.Rentals
                                 .Include(c => c.Customer)
                                 .Include(c => c.Car)
                                 .FirstOrDefaultAsync(r => r.Id == rentalId);
        }

        #endregion
    }
}
