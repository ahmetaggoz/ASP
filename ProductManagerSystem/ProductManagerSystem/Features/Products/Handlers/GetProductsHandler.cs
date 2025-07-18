using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductManagerSystem.Data;
using ProductManagerSystem.Models;

namespace ProductManagerSystem.Features.Products.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, List<Product>>
    {
        private readonly AppDbContext _context;

        public GetProductsHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Products.ToListAsync(cancellationToken);
        }
    }
}
