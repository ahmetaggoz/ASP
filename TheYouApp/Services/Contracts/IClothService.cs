using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestFeatures;

namespace Services.Contracts
{
    public interface IClothService
    {
        Task<(IEnumerable<ClothesDto> clothesDtos, MetaData metaData  )> GetAllClothesAsync(ClothParameters clothParameters, bool trackChanges);
        Task<ClothesDto> GetOneClothByIdAsync(int id, bool trackChanges);
        Task<ClothesDto> CreateOneClothAsync(ClothesDtoForInsertion cloth);
        Task UpdateClothAsync(int id, ClothesDtoForUpdate clothDto, bool trackChanges);
        Task DeleteClothAsync(int id, bool trackChanges);
        Task<(ClothesDtoForUpdate clothesDtoForUpdate, Clothes cloth)> GetOneClothForPatchAsync(int id, bool trackChanges);
        Task SaveChangesForPatchAsync(ClothesDtoForUpdate clothDtoForUpdate, Clothes clothes);
    }
}
