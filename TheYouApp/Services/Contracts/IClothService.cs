using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IClothService
    {
        IEnumerable<Clothes> GetAllClothes(bool trackChanges);
        Clothes GetOneClothById(int id, bool trackChanges);
        Clothes CreateOneCloth(Clothes cloth);
        void UpdateCloth(int id, Clothes cloth, bool trackChanges);
        void DeleteCloth(int id, bool trackChanges);
    }
}
