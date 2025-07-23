using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _manager;

        public CategoryManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public void CreateCategory(Category category)
        {
            _manager.Category.Create(category);
            _manager.Save();
        }

        public void DeleteCategory(Category category)
        {
            _manager.Category.Remove(category);
            _manager.Save();
        }

        public IEnumerable<Category> GetAllCategories(bool trackChanges)
        {
            return _manager.Category.FindAll(trackChanges);
        }

        public Category? GetOneCategory(int id)
        {
            var value = _manager.Category.FindByCondition(c => c.CategoryId.Equals(id), true);
            _manager.Save();
            return value;
        }

        public void UpdateCategory(Category category)
        {
            _manager.Category.Update(category);
            _manager.Save();
        }
    }
}