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
        public ClothesManager(IRepositoryManager manager, ILoggerService logger)
        {
            _manager = manager;
            _logger = logger;
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
            {
                string message = $"Cloth with id:{id} could not found!";
                _logger.LogInfo(message);
                throw new Exception(message);
            }
            _manager.Clothes.Delete(cloth);
            _manager.Save();

        }

        public IEnumerable<Clothes> GetAllClothes(bool trackChanges)
        {
            return _manager.Clothes.GetAllClothes(trackChanges);
        }

        public Clothes GetOneClothById(int id, bool trackChanges)
        {
            return _manager.Clothes.GetOneClothesById(id, trackChanges);
        }

        public void UpdateCloth(int id, Clothes cloth, bool trackChanges)
        {
            var entity = _manager.Clothes.GetOneClothesById(id, trackChanges);
            if (entity is null)
            {
                string message = $"Cloth with id:{id} could not found!";
                _logger.LogInfo(message);
                throw new Exception(message);
            }
                

            if (cloth is null)
                throw new ArgumentNullException(nameof(cloth));

            entity.Name = cloth.Name;
            entity.Price = cloth.Price;

            _manager.Clothes.Update(entity);
            _manager.Save();
        }
    }
}
