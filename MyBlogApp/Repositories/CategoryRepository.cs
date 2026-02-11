using Entities;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateCategory(Category category) => Create(category);


        public void DeleteCategory(Category category) => Delete(category);


        public IEnumerable<Category> GetAllCategories() => FindAll(true);


        public Category? GetById(int id) => FindByCondition(c => c.Id.Equals(id),true);


        public void UpdateCategory(Category category) => Update(category);
        
    }
}
