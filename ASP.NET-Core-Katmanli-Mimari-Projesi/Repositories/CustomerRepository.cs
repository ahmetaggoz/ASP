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
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context) { }


        public async Task<IEnumerable<Customer>> GetActiveCustomerAsync()
        {
            return await _dbSet.Where(c => c.IsActive).ToListAsync();
        }
        public async Task<Customer?> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.Email.Equals(email));
        }

        public async Task<IEnumerable<Customer>> SearchCustomersAsync(string searchTerm)
        {
            return await _dbSet
                .Where(c => c.FirstName.Contains(searchTerm) ||
                            c.LastName.Contains(searchTerm) ||
                            c.Email.Contains(searchTerm))
                .ToListAsync();
        }

    }
}
