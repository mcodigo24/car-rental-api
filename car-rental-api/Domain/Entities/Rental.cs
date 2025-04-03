using System.ComponentModel.DataAnnotations;

namespace car_rental_api.Domain.Entities
{
    public class Rental
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Required]
        public int CarId { get; set; }
        public Car Car { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public int RentalStatusId { get; set; }
        public RentalStatus RentalStatus { get; set; } = null!;
    }
}
