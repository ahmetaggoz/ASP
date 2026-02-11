using Entities.Dtos;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IMappingService
    {
        CustomerDto MapToCustomerDto(Customer customer);
        Customer MapToCustomer(CreateCustomerDto createCustomerDto);
        void MapToCustomer(UpdateCustomerDto updateCustomerDto, Customer customer);

        ProductDto MapToProductDto(Product product);
        Product MapToProduct(CreateProductDto createProductDto);

        OrderDto MapToOrderDto(Order order);
        Order MapToOrder(CreateOrderDto createOrderDto);

        IEnumerable<CategoryDto> MapToCategoryDtoForAllCategories(IEnumerable<Category> categories);
        Category MapToCategory(CategoryDto categoryDto);
    }
}
