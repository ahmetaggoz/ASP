using MediatR;
using ProductManagerSystem.Data;

namespace ProductManagerSystem.Features.Products.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly AppDbContext _context;
        public UpdateProductHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Product;
            var product = await _context.Products.FindAsync(new object[] { request.Id }, cancellationToken);
            if (product is null) return false; // Product not found
            product.Name = dto.Name;
            product.Price = dto.Price;
            _context.Products.Update(product);
            await _context.SaveChangesAsync(cancellationToken);
            return true; // Update successful

            //var product = await _context.Products.FindAsync(new object [] {request.Id}, cancellationToken);
            //if (product is null) return false;

            //product.Name = request.Name;
            //product.Price = request.Price;
            //_context.Products.Update(product);
            //await _context.SaveChangesAsync(cancellationToken);
            //return true; // Update successful
        }
    }
}
