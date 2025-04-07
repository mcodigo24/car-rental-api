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
                Address = entity.Address,
                PersonId = entity.PersonId
            };
        }

        public static Customer ToEntity(this CustomerDto dto)
        {
            return new()
            {                
                FullName = dto.FullName,
                Address = dto.Address,
                PersonId = dto.PersonId
            };
        }        

        public static Customer ToUpdateEntity(this Customer entity, CustomerDto dto)
        {
            entity.Id = dto.Id;
            entity.FullName = dto.FullName; 
            entity.Address = dto.Address;
            entity.PersonId = dto.PersonId;
            return entity;
        }
    }
}
