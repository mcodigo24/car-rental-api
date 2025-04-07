using car_rental_api.Domain.Enums;

namespace car_rental_api.Application.Dtos
{
    public class RentalResponseDto
    {
        public int Id { get; set; }        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public CarDto Car { get; set; }
        public CustomerDto Customer { get; set; }
    }
}
