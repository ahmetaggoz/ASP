using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class ClothesRepository : RepositoryBase<Clothes>, IClothesRepository
    {
        public ClothesRepository(RepositoryContext context) : base(context)
        {

        }

        public void CreateOneClothes(Clothes clothes) =>
            Create(clothes);


        public void DeleteOneClothes(Clothes clothes) =>
            Delete(clothes);


        public IQueryable<Clothes> GetAllClothes(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(c => c.Id);


        public Clothes GetOneClothesById(int id, bool trackChanges) =>
            FindByCondition(c => c.Id.Equals(id), trackChanges)
            .SingleOrDefault();


        public void UpdateOneClothes(Clothes clothes) =>
            Update(clothes);

    }
}
