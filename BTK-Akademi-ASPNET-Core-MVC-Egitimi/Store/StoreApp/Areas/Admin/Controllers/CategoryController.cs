using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class CategoryController : Controller
    {
        private readonly IServiceManager _manager;

        public CategoryController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            return View(_manager.CategoryService.GetAllCategories(false));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryCreateDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var category = new Category
            {
                CategoryName = model.CategoryName
            };

            _manager.CategoryService.CreateCategory(category);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int id)
        {
            var category = _manager.CategoryService.GetOneCategory(id);
            var model = new CategoryUpdateDto
            {
                CategoryName = category.CategoryName,
                Id = category.CategoryId
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(CategoryUpdateDto model)
        {
            var category = _manager.CategoryService.GetOneCategory(model.Id);
            category.CategoryName = model.CategoryName;

            _manager.CategoryService.UpdateCategory(category);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {

            var model = _manager.CategoryService.GetOneCategory(id);
            _manager.CategoryService.DeleteCategory(model);
            return RedirectToAction(nameof(Index));
        }
    }
}