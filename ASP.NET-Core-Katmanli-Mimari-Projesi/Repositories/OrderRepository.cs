using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepository : GenericRepository<Order> ,IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerAsync(int customerId)
        {
            return await _dbSet.Where(c => c.CustomerId.Equals(customerId)).ToListAsync();
            
            
        }

        public Task<IEnumerable<Order>> GetOrdersByStatusAsync(Order.OrderStatus status)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderWithItemsAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<Order?> UpdateAsync(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
