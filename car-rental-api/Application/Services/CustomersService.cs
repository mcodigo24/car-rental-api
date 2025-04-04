using car_rental_api.Application.Dtos;
using car_rental_api.Application.Interfaces;
using car_rental_api.Application.Mappers;
using car_rental_api.Domain.Repositories;
using car_rental_api.Infrastructure.Repositories;

namespace car_rental_api.Application.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly ICustomersRepository _customerRepository;

        public CustomersService(ICustomersRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerDto?> AddIfNotExistsAsync(CustomerDto customerDto)
        {
            if (!await _customerRepository.ExistsByFullNameAsync(customerDto.FullName))
            {
                var customer = customerDto.ToEntity();
                var customerId = await _customerRepository.AddAsync(customer);
                customerDto.Id = customerId;

                return customerDto;
            }

            return null;
        }

        public async Task<CustomerDto> GetByFullNameAsync(string fullName)
        {
            var customer = await _customerRepository.GetByFullNameAsync(fullName) ?? throw new KeyNotFoundException("Customer not found.");
            return customer.ToDto();
        }
    }
}
