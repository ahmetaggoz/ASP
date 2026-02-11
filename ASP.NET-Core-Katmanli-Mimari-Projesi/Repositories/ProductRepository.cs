using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public Task<IEnumerable<Product>> GetActiveProductsAsync()
        {
            throw new NotImplementedException();
        }


        public Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateStockAsync(int productId, int newStock)
        {
            throw new NotImplementedException();
        }
    }
}
