using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IClothesRepository : IRepositoryBase<Clothes>
    {
        // Add any additional methods specific to Clothes repository if needed
        IQueryable<Clothes> GetAllClothes(bool trackChanges);
        Clothes GetOneClothesById(int id, bool trackChanges);
        void CreateOneClothes(Clothes clothes);
        void UpdateOneClothes(Clothes clothes);
        void DeleteOneClothes(Clothes clothes);
    }
}
