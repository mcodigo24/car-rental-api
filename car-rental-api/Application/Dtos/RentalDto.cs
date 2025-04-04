using car_rental_api.Domain.Enums;

namespace car_rental_api.Application.Dtos
{
    public class RentalDto
    {
        public int Id { get; set; }        
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public RentalStatusEnum Status { get; set; }
    }
}
