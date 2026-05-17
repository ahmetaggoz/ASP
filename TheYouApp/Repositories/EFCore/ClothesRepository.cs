using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public sealed class ClothesRepository : RepositoryBase<Clothes>, IClothesRepository
    {
        public ClothesRepository(RepositoryContext context) : base(context)
        {

        }

        public void CreateOneClothes(Clothes clothes) =>
            Create(clothes);


        public void DeleteOneClothes(Clothes clothes) =>
            Delete(clothes);


        public async Task<PagedList<Clothes>> GetAllClothesAsync(ClothParameters clothParameters, bool trackChanges)
        {
            var clothes = await FindAll(trackChanges)
            .FilterClothesByPrice(clothParameters.MinPrice,clothParameters.MaxPrice)
            .Search(clothParameters.SearchTerm)
            .Sort(clothParameters.OrderBy)
            .ToListAsync();
            return PagedList<Clothes>.ToPagedList(clothes, clothParameters.PageNumber, clothParameters.PageSize);
        }

        public async Task<Clothes> GetOneClothesByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();


        public void UpdateOneClothes(Clothes clothes) =>
            Update(clothes);

    }
}
