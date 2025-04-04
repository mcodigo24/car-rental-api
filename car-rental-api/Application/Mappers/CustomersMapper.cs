using car_rental_api.Application.Dtos;
using car_rental_api.Domain.Entities;

namespace car_rental_api.Application.Mappers
{
    public static class CustomersMapper
    {
        public static CustomerDto ToDto(this Customer entity)
        {
            return new()
            {
                Id = entity.Id,
                FullName = entity.FullName,
                Address = entity.Address
            };
        }

        public static Customer ToEntity(this CustomerDto dto)
        {
            return new()
            {                
                FullName = dto.FullName,
                Address = dto.Address
            };
        }

        public static Customer ToEntity(this CustomerDto dto, int id)
        {
            var customer = dto.ToEntity();
            customer.Id = id;
            return customer;
        }
    }
}
