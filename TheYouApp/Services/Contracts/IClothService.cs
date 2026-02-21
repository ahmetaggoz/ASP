using Entities.DataTransferObjects;
using Entities.Models;

namespace Services.Contracts
{
    public interface IClothService
    {
        IEnumerable<ClothesDto> GetAllClothes(bool trackChanges);
        ClothesDto GetOneClothById(int id, bool trackChanges);
        ClothesDto CreateOneCloth(ClothesDtoForInsertion cloth);
        void UpdateCloth(int id, ClothesDtoForUpdate clothDto, bool trackChanges);
        void DeleteCloth(int id, bool trackChanges);
        (ClothesDtoForUpdate clothesDtoForUpdate, Clothes cloth) GetOneClothForPatch(int id, bool trackChanges);
        void SaveChangesForPatch(ClothesDtoForUpdate clothDtoForUpdate, Clothes clothes);
    }
}
