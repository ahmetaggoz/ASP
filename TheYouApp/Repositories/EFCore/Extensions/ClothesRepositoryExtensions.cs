using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace Repositories.EFCore.Extensions
{
    public static class ClothesRepositoryExtensions
    {
        public static IQueryable<Clothes> FilterClothesByPrice(this IQueryable<Clothes> clothes, uint minPrice, uint maxPrice) =>
            clothes.Where(c => c.Price >= minPrice && c.Price <= maxPrice);

        public static IQueryable<Clothes> Search(this IQueryable<Clothes> clothes, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return clothes;
            var lowerCaseSearchTerm = searchTerm.Trim().ToLower();
            return
                clothes.Where(c => c.Name.ToLower().Contains(lowerCaseSearchTerm));
        }

        public static IQueryable<Clothes> Sort(this IQueryable<Clothes> clothes, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return clothes.OrderBy(c => c.Id);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Clothes>(orderByQueryString);
            if (orderQuery is null)
                return clothes.OrderBy(c => c.Id);
            return clothes.OrderBy(orderQuery);

        }
    }
}
