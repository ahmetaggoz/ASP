using Entities.Dtos;
using Microsoft.Extensions.Logging;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMappingService _mappingService;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(ICustomerRepository customerRepository, IMappingService mappingService, ILogger<CustomerService> logger)
        {
            _customerRepository = customerRepository;
            _mappingService = mappingService;
            _logger = logger;
        }

        public async Task<CustomerDto> CreateCustomerAsync(CreateCustomerDto createCustomerDto)
        {
            try
            {
                // Business rule: Check if email already exists
                var existingCustomer = await _customerRepository.GetByEmailAsync(createCustomerDto.Email);
                if (existingCustomer != null)
                {
                    throw new InvalidOperationException("Bu email adresi ile kayıtlı bir müşteri zaten var.");
                }

                var customer = _mappingService.MapToCustomer(createCustomerDto);
                var createdCustomer = await _customerRepository.AddAsync(customer);

                _logger.LogInformation("Customer created with id {CustomerId}", createdCustomer.Id);
                return _mappingService.MapToCustomerDto(createdCustomer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating customer");
                throw;
            }
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            try
            {
                var result = await _customerRepository.DeleteAsync(id);
                if (result)
                {
                    _logger.LogInformation("Customer deleted with id {CustomerId}", id);
                }
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting customer with id {CustomerId}", id);
                throw;
            }
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
        {
            try
            {
                var customers = await _customerRepository.GetAllAsync();
                return customers.Select(c => _mappingService.MapToCustomerDto(c));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting all customers");
                throw;
            }
        }

        public async Task<CustomerDto?> GetCustomerByIdAsync(int id)
        {
            try
            {
                var customer = await _customerRepository.GetByIdAsync(id);
                return _mappingService.MapToCustomerDto(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting customer with id {CustomerId}", id);
                throw;
            }
        }

        public async Task<IEnumerable<CustomerDto>> SearchCustomersAsync(string searchTerm)
        {
            try
            {
                var customers = await _customerRepository.SearchCustomersAsync(searchTerm);
                return customers.Select(c => _mappingService.MapToCustomerDto(c));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while searching customers with term {SearchTerm}", searchTerm);
                throw;
            }
        }

        public async Task<CustomerDto> UpdateCustomerAsync(UpdateCustomerDto updateCustomerDto)
        {
            try
            {
                var existingCustomer = await _customerRepository.GetByIdAsync(updateCustomerDto.Id);
                if (existingCustomer == null)
                {
                    throw new ArgumentException("Müşteri bulunamadı.");
                }

                // Business rule: Check if new email conflicts with another customer
                var customerWithSameEmail = await _customerRepository.GetByEmailAsync(updateCustomerDto.Email);
                if (customerWithSameEmail != null && customerWithSameEmail.Id != updateCustomerDto.Id)
                {
                    throw new InvalidOperationException("Bu email adresi başka bir müşteri tarafından kullanılıyor.");
                }

                _mappingService.MapToCustomer(updateCustomerDto, existingCustomer);
                var updatedCustomer = await _customerRepository.UpdateAsync(existingCustomer);

                _logger.LogInformation("Customer updated with id {CustomerId}", updatedCustomer.Id);
                return _mappingService.MapToCustomerDto(updatedCustomer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating customer with id {CustomerId}", updateCustomerDto.Id);
                throw;
            }
        }
    }
}
