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

        public static RentalResponseDto ToResponseDto(this Rental rental)
        {
            return new()
            {
                Id = rental.Id,
                StartDate = rental.StartDate,
                EndDate = rental.EndDate,
                Car = rental.Car.ToDto(),
                Customer = rental.Customer.ToDto()
            };
        }

        public static List<RentalResponseDto> ToListResponseDto(this List<Rental> list)
        {
            return [.. list.Select(r => r.ToResponseDto())];
        }

        public static Rental ToUpdateEntity(this Rental entity, RentalDto dto)
        {
            entity.Id = dto.Id;
            entity.StartDate = dto.StartDate;
            entity.EndDate = dto.EndDate;
            entity.CarId = dto.CarId;
            entity.CustomerId = dto.CustomerId;
            return entity;
        }
    }
}
