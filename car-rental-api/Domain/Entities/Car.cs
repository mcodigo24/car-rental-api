using System.ComponentModel.DataAnnotations;

namespace car_rental_api.Domain.Entities
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Type { get; set; }

        [Required, MaxLength(100)]
        public string Model { get; set; }

        public List<Service> Services { get; set; }
    }
}
