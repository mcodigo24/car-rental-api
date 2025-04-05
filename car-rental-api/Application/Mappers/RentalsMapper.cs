using car_rental_api.Application.Dtos;
using car_rental_api.Domain.Entities;

namespace car_rental_api.Application.Mappers
{
    public static class RentalsMapper
    {
        public static RentalDto ToDto(this Rental rental)
        {
            return new()
            {
                Id = rental.Id,
                CarId = rental.CarId,
                StartDate = rental.StartDate,
                EndDate = rental.EndDate,
                CustomerId = rental.CustomerId
            };
        }

        public static List<RentalDto> ToListDto(this List<Rental> list)
        {
            return [.. list.Select(r => r.ToDto())];
        }

        public static Rental ToEntity(this RentalDto dto)
        {
            return new()
            {
                CarId = dto.CarId,
                CustomerId = dto.CustomerId,
                RentalStatusId = (int)dto.Status,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate
            };
        }

        public static Rental ToEntity(this RentalDto dto, int id)
        {
            var rental = dto.ToEntity();
            rental.Id = id;
            return rental;
        }
    }
}
