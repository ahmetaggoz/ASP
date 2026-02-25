using Entities.Models;
using Microsoft.EntityFrameworkCore;
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


        public async Task<IEnumerable<Clothes>> GetAllClothesAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(c => c.Id)
            .ToListAsync();


        public async Task<Clothes> GetOneClothesByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();


        public void UpdateOneClothes(Clothes clothes) =>
            Update(clothes);

    }
}
