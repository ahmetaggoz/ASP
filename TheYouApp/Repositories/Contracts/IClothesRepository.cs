using Entities.Models;
using Entities.RequestFeatures;


namespace Repositories.Contracts
{
    public interface IClothesRepository : IRepositoryBase<Clothes>
    {
        // Add any additional methods specific to Clothes repository if needed
        Task<PagedList<Clothes>> GetAllClothesAsync(ClothParameters clothParameters, bool trackChanges);
        Task<Clothes> GetOneClothesByIdAsync(int id, bool trackChanges);
        void CreateOneClothes(Clothes clothes);
        void UpdateOneClothes(Clothes clothes);
        void DeleteOneClothes(Clothes clothes);
    }
}
