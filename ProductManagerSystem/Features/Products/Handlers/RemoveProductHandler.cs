using MediatR;
using ProductManagerSystem.Data;

namespace ProductManagerSystem.Features.Products.Handlers
{
    public class RemoveProductHandler : IRequestHandler<RemoveProductCommand, bool>
    {
        private readonly AppDbContext _context;
        public RemoveProductHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FindAsync(new object []{request.Id});
            if (product is null) return false;
            _context.Products.Remove(product);
            await _context.SaveChangesAsync(cancellationToken);
            return true;

        }
    }
}
