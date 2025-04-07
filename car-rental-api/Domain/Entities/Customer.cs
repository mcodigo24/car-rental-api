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

        [Required, MaxLength(50)]
        public string PersonId { get; set; }

        public List<Rental> Rentals { get; set; }
    }
}
