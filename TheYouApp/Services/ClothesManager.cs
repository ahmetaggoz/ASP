using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ClothesManager : IClothService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        public ClothesManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<ClothesDto> CreateOneClothAsync(ClothesDtoForInsertion clothDto)
        {
            var entity = _mapper.Map<Clothes>(clothDto);
            _manager.Clothes.Create(entity);
            await _manager.SaveAsync();
            return _mapper.Map<ClothesDto>(entity);
        }

        public async Task DeleteClothAsync(int id, bool trackChanges)
        {
            var entity = await GetClothAndCheckIfItExists(id, trackChanges);
            _manager.Clothes.Delete(entity);
            await _manager.SaveAsync();

        }

        public async Task<(IEnumerable<ClothesDto> clothesDtos, MetaData metaData)> GetAllClothesAsync(ClothParameters clothParameters, bool trackChanges)
        {
            if (!clothParameters.ValidPriceRange)
                throw new PriceOutOfRangeException();
            var clothesWithMetaData = await _manager.Clothes.GetAllClothesAsync(clothParameters, trackChanges);
            var clothesDto = _mapper.Map<IEnumerable<ClothesDto>>(clothesWithMetaData);
            return (clothesDto, clothesWithMetaData.MetaData);
        }

        public async Task<ClothesDto> GetOneClothByIdAsync(int id, bool trackChanges)
        {
            var cloth = await GetClothAndCheckIfItExists(id, trackChanges);
            
            return _mapper.Map<ClothesDto>(cloth);
        }

        public async Task<(ClothesDtoForUpdate clothesDtoForUpdate, Clothes cloth)> GetOneClothForPatchAsync(int id, bool trackChanges)
        {
            var cloth = await GetClothAndCheckIfItExists(id, trackChanges);
            var clothDtoForUpdate = _mapper.Map<ClothesDtoForUpdate>(cloth);
            return (clothDtoForUpdate, cloth);
        }

        public async Task SaveChangesForPatchAsync(ClothesDtoForUpdate clothDtoForUpdate, Clothes clothes)
        {
            _mapper.Map(clothDtoForUpdate, clothes);
            await _manager.SaveAsync();
        }

        public async Task UpdateClothAsync(int id, ClothesDtoForUpdate clothesDto, bool trackChanges)
        {
            var entity = await GetClothAndCheckIfItExists(id, trackChanges);
            entity = _mapper.Map<Clothes>(clothesDto);
            _manager.Clothes.Update(entity);
            await _manager.SaveAsync();
        }

        private async Task<Clothes> GetClothAndCheckIfItExists(int id, bool trackChanges)
        {
            var cloth = await _manager.Clothes.GetOneClothesByIdAsync(id, trackChanges);
            if (cloth is null)
                throw new ClothNotFoundException(id);
            return cloth;
        }
    }
}
