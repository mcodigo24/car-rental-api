using car_rental_api.Application.Dtos;
using car_rental_api.Application.Interfaces;
using car_rental_api.Domain.Entities;
using car_rental_api.Domain.Repositories;

namespace car_rental_api.Application.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly ICustomersRepository _customerRepository;

        public CustomersService(ICustomersRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task AddAsync(CustomerDto customerDto)
        {
            var customer = new Customer
            {
                FullName = customerDto.FullName,
                Address = customerDto.Address
            };

            await _customerRepository.AddAsync(customer);
        }
    }
}
