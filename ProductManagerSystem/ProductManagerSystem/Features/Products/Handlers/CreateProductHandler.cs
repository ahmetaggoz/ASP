using MediatR;
using ProductManagerSystem.Data;
using ProductManagerSystem.Models;

namespace ProductManagerSystem.Features.Products.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly AppDbContext _context;

        public CreateProductHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Product;
            var product = new Product { Name = dto.Name, Price = dto.Price };
            
            _context.Products.Add(product);
            await _context.SaveChangesAsync(cancellationToken);
            return product.Id; // Assuming Id is the primary key and is auto-generated
        }
    }
}
