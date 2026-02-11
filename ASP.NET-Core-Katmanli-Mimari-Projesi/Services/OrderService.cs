using Entities.Dtos;
using Entities.Models;
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
    public class OrderService : IOrderService
    {
        private readonly IMappingService _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<OrderService> _logger;

        public OrderService(IMappingService mapper, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public Task<OrderDto> CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDto> GetOrderByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersByCustomerAsync(int customerId)
        {
            try
            {
                var orders = await _orderRepository.GetOrdersByCustomerAsync(customerId);
                return orders.Select(o => _mapper.MapToOrderDto(o));

            }catch(Exception ex)
            {
                _logger.LogError(ex, "Error occurred while get orders customer with id {CustomerId}", customerId);
                throw;
            }           
        }

        public Task<bool> UpdateOrderStatusAsync(int orderId, Order.OrderStatus newStatus)
        {
            throw new NotImplementedException();
        }
    }
}
