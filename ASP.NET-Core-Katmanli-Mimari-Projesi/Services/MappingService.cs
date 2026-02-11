using Entities.Dtos;
using Entities.Models;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entities.Models.Order;

namespace Services
{
    public class MappingService : IMappingService
    {
        public Category MapToCategory(CategoryDto categoryDto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoryDto> MapToCategoryDtoForAllCategories(IEnumerable<Category> categories)
        {
            List<CategoryDto> categoryDtos = new List<CategoryDto>();
            foreach (var category in categories)
            {
                var model = new CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name,
                    CreatedDate = category.CreatedDate,
                    Description = category.Description,
                    IsActive = category.IsActive
                };
                categoryDtos?.Add(model);
            }
            IEnumerable<CategoryDto> categoryDtos1 = categoryDtos;
            return categoryDtos;
        }

        public Customer MapToCustomer(CreateCustomerDto createCustomerDto)
        {
            return new Customer
            {
                FirstName = createCustomerDto.FirstName,
                LastName = createCustomerDto.LastName,
                Email = createCustomerDto.Email,
                CreatedDate = DateTime.Now,
                IsActive = true
            };
        }

        public void MapToCustomer(UpdateCustomerDto updateCustomerDto, Customer customer)
        {
            customer.FirstName = updateCustomerDto.FirstName;
            customer.LastName = updateCustomerDto.LastName;
            customer.Email = updateCustomerDto.Email;
            customer.IsActive = updateCustomerDto.IsActive;
        }

        public CustomerDto MapToCustomerDto(Customer customer)
        {
            if (customer == null) return null;

            return new CustomerDto
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                CreatedDate = customer.CreatedDate,
                IsActive = customer.IsActive
            };
        }

        public Order MapToOrder(CreateOrderDto createOrderDto)
        {
            return new Order
            {
                CustomerId = createOrderDto.CustomerId,
                OrderDate = DateTime.Now,
                Status = OrderStatus.Pending,
                TotalAmount = 0, // Will be calculated in service
                OrderItems = createOrderDto.OrderItems.Select(oi => new OrderItem
                {
                    ProductId = oi.ProductId,
                    Quantity = oi.Quantity,
                    UnitPrice = 0, // Will be set from product price
                    TotalPrice = 0  // Will be calculated
                }).ToList()
            };
        }

        public OrderDto MapToOrderDto(Order order)
        {
            if (order == null) return null;

            return new OrderDto
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                CustomerName = order.Customer != null ? $"{order.Customer.FirstName} {order.Customer.LastName}" : "",
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                Status = order.Status,
                StatusText = order.Status.ToString(),
                OrderItems = order.OrderItems?.Select(oi => new OrderItemDto
                {
                    Id = oi.Id,
                    ProductId = oi.ProductId,
                    ProductName = oi.Product?.Name,
                    Quantity = oi.Quantity,
                    UnitPrice = oi.UnitPrice,
                    TotalPrice = oi.TotalPrice
                }).ToList() ?? new List<OrderItemDto>()
            };
        }

        public Product MapToProduct(CreateProductDto createProductDto)
        {
            return new Product
            {
                Name = createProductDto.Name,
                Description = createProductDto.Description,
                Price = createProductDto.Price,
                Stock = createProductDto.Stock,
                CategoryId = createProductDto.CategoryId,
                CreatedDate = DateTime.Now,
                IsActive = true
            };
        }

        public ProductDto MapToProductDto(Product product)
        {
            if (product == null) return null;

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                CategoryId = product.CategoryId,
                CategoryName = product.Category?.Name,
                CreatedDate = product.CreatedDate,
                IsActive = product.IsActive
            };
        }
    }
}
