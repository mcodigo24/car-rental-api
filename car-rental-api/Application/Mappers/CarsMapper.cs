using car_rental_api.Application.Dtos;
using car_rental_api.Domain.Entities;

namespace car_rental_api.Application.Mappers
{
    public static class CarsMapper
    {
        public static CarDto ToDto(this Car entity)
        {
            return new()
            {
                Id = entity.Id,
                Model = entity.Model,
                Type = entity.Type,
            };
        }

        public static List<CarDto> ToListDto(this List<Car> list)
        {
            return [.. list.Select(r => r.ToDto())];
        }
    }
}
