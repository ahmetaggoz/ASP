

namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IClothesRepository Clothes { get; }
        Task SaveAsync();
    }
}
