using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
