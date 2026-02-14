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
        public Clothes CreateOneCloth(Clothes cloth)
        {
            _manager.Clothes.Create(cloth);
            _manager.Save();
            return cloth;
        }

        public void DeleteCloth(int id, bool trackChanges)
        {
            var cloth = _manager.Clothes.GetOneClothesById(id, trackChanges);
            if (cloth is null)
                throw new ClothNotFoundException(id);
            _manager.Clothes.Delete(cloth);
            _manager.Save();

        }

        public IEnumerable<Clothes> GetAllClothes(bool trackChanges)
        {
            return _manager.Clothes.GetAllClothes(trackChanges);
        }

        public Clothes GetOneClothById(int id, bool trackChanges)
        {
            var cloth = _manager.Clothes.GetOneClothesById(id, trackChanges);
            if (cloth is null)
                throw new ClothNotFoundException(id);
            return cloth;
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
