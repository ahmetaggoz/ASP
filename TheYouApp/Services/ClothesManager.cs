using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public ClothesDto CreateOneCloth(ClothesDtoForInsertion clothDto)
        {
            var entity = _mapper.Map<Clothes>(clothDto);
            _manager.Clothes.Create(entity);
            _manager.Save();
            return _mapper.Map<ClothesDto>(entity);
        }

        public void DeleteCloth(int id, bool trackChanges)
        {
            var cloth = _manager.Clothes.GetOneClothesById(id, trackChanges);
            if (cloth is null)
                throw new ClothNotFoundException(id);
            _manager.Clothes.Delete(cloth);
            _manager.Save();

        }

        public IEnumerable<ClothesDto> GetAllClothes(bool trackChanges)
        {
            var clothes = _manager.Clothes.GetAllClothes(trackChanges);
            return _mapper.Map<IEnumerable<ClothesDto>>(clothes);
        }

        public ClothesDto GetOneClothById(int id, bool trackChanges)
        {
            var cloth = _manager.Clothes.GetOneClothesById(id, trackChanges);
            if (cloth is null)
                throw new ClothNotFoundException(id);
            return _mapper.Map<ClothesDto>(cloth);
        }

        public (ClothesDtoForUpdate clothesDtoForUpdate, Clothes cloth) GetOneClothForPatch(int id, bool trackChanges)
        {
            var cloth = _manager.Clothes.GetOneClothesById(id, trackChanges);
            if(cloth is null)
                throw new ClothNotFoundException(id);
            var clothDtoForUpdate = _mapper.Map<ClothesDtoForUpdate>(cloth);
            return (clothDtoForUpdate, cloth);
        }

        public void SaveChangesForPatch(ClothesDtoForUpdate clothDtoForUpdate, Clothes clothes)
        {
            _mapper.Map(clothDtoForUpdate, clothes);
            _manager.Save();
        }

        public void UpdateCloth(int id, ClothesDtoForUpdate clothesDto, bool trackChanges)
        {
            var entity = _manager.Clothes.GetOneClothesById(id, trackChanges);
            if (entity is null)
                throw new ClothNotFoundException(id);

            entity = _mapper.Map<Clothes>(clothesDto);


            _manager.Clothes.Update(entity);
            _manager.Save();
        }
    }
}
