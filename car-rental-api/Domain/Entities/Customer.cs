using System.ComponentModel.DataAnnotations;

namespace car_rental_api.Domain.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string FullName { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        [Required]
        public int IdNumber { get; set; }

        public List<Rental> Rentals { get; set; }
    }
}
