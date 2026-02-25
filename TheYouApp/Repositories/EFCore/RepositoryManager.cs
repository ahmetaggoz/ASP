using Repositories.Contracts;


namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<IClothesRepository> _clothesRepository;
        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _clothesRepository = new Lazy<IClothesRepository>(() => new ClothesRepository(_context));
        }
        // Implement the properties for each repository interface
        public IClothesRepository Clothes => _clothesRepository.Value;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
