using car_rental_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace car_rental_api.Infrastructure.Persistence.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<RentalStatus> RentalStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<Car>()
                .HasMany(c => c.Services)
                .WithOne(s => s.Car)
                .HasForeignKey(s => s.CarId);
            
            modelBuilder.Entity<Rental>()
                .HasOne(r => r.Customer)
                .WithMany()
                .HasForeignKey(r => r.CustomerId);
            
            modelBuilder.Entity<Rental>()
                .HasOne(r => r.Car)
                .WithMany()
                .HasForeignKey(r => r.CarId);

            modelBuilder.Entity<Rental>()
                .HasOne(r => r.RentalStatus)
                .WithMany()
                .HasForeignKey(r => r.RentalStatusId);
        }
    }
}
