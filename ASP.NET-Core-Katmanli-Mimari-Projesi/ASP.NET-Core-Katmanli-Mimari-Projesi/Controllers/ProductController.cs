using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;
using System.Collections.Generic;
using static ASP.NET_Core_Katmanli_Mimari_Projesi.Models.ProductViewModel;

namespace ASP.NET_Core_Katmanli_Mimari_Projesi.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IMappingService _mapping;
        private readonly ILogger<ProductController> _logger;


        public ProductController(IProductService productService, ICategoryService categoryService, IMappingService mapping, ILogger<ProductController> logger)
        {
            _productService = productService;
            _categoryService = categoryService;
            _mapping = mapping;
            _logger = logger;
        }

        public async Task<IActionResult> Index(int? categoryId, string searchTerm = "")
        {
            try
            {
                var products = categoryId.HasValue
                    ? await _productService.GetProductsByCategoryAsync(categoryId.Value)
                    : await _productService.GetAllProductsAsync();

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    products = products.Where(p => p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
                }

                IEnumerable<Category> categories = await _categoryService.GetAllCategoriesAsync();
                IEnumerable<CategoryDto> categoriesDto = _mapping.MapToCategoryDtoForAllCategories(categories);

                var viewModel = new ProductListViewModel
                {
                    Products = products,
                    Categories = categoriesDto,
                    SelectedCategoryId = categoryId,
                    SearchTerm = searchTerm,
                    TotalCount = products.Count()
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while loading products");
                TempData["ErrorMessage"] = "Ürünler yüklenirken bir hata oluştu.";
                return View(new ProductListViewModel());
            }
        }
        public async Task<IActionResult> Create()
        {
            try
            {
                var categories = await _categoryService.GetAllCategoriesAsync();
                IEnumerable<CategoryDto> categoriesDto = _mapping.MapToCategoryDtoForAllCategories(categories);
                var viewModel = new ProductCreateViewModel
                {
                    Categories = categoriesDto
                };
                var models = new SelectList(viewModel.Categories, "Id", "Name", "1");
                ViewBag.Categories = models;
                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while loading categories for product creation");
                TempData["ErrorMessage"] = "Sayfa yüklenirken bir hata oluştu.";
                return RedirectToAction(nameof(Index));
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                try
                {
                    IEnumerable<Category> categories = await _categoryService.GetAllCategoriesAsync();
                    model.Categories = _mapping.MapToCategoryDtoForAllCategories(categories);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occurred while loading categories");
                }
                return View(model);
            }

            try
            {
                await _productService.CreateProductAsync(model.Product);
                TempData["SuccessMessage"] = "Ürün başarıyla oluşturuldu.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating product");
                ModelState.AddModelError("", "Ürün oluşturulurken bir hata oluştu.");

                try
                {
                    IEnumerable<Category> categories = await _categoryService.GetAllCategoriesAsync();
                    model.Categories = _mapping.MapToCategoryDtoForAllCategories(categories);
                }
                catch { }

                return View(model);
            }
        }
        
    }
}
