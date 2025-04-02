using System.ComponentModel.DataAnnotations;

namespace car_rental_api.Domain.Entities
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
