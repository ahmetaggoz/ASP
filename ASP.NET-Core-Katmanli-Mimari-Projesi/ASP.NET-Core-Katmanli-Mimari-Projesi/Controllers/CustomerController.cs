using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using static ASP.NET_Core_Katmanli_Mimari_Projesi.Models.CustomerViewModel;

namespace ASP.NET_Core_Katmanli_Mimari_Projesi.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IOrderService _orderService;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerService customerService, IOrderService orderService, ILogger<CustomerController> logger)
        {
            _customerService = customerService;
            _orderService = orderService;
            _logger = logger;
        }

        public async Task<IActionResult> Index(string searchTerm = "")
        {
            try
            {
                var customers = string.IsNullOrEmpty(searchTerm)
                    ? await _customerService.GetAllCustomersAsync()
                    : await _customerService.SearchCustomersAsync(searchTerm);

                var viewModel = new CustomerListViewModel
                {
                    Customers = customers,
                    SearchTerm = searchTerm,
                    TotalCount = customers.Count()
                };
                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while loading customers");
                TempData["ErrorMessage"] = "Müşteriler yüklenirken bir hata oluştu.";
                return View(new CustomerListViewModel());
            }
        }
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var customer = await _customerService.GetCustomerByIdAsync(id);
                if (customer == null)
                {
                    return NotFound();
                }

                var recentOrders = await _orderService.GetOrdersByCustomerAsync(id);

                var viewModel = new CustomerDetailsViewModel
                {
                    Customer = customer,
                    RecentOrders = recentOrders.Take(5)
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while loading customer details for id {CustomerId}", id);
                TempData["ErrorMessage"] = "Müşteri bilgileri yüklenirken bir hata oluştu.";
                return RedirectToAction(nameof(Index));
            }
        }
        public IActionResult Create(string? returnUrl = null)
        {
            var viewModel = new CustomerCreateViewModel
            {
                ReturnUrl = returnUrl
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await _customerService.CreateCustomerAsync(model.Customer);
                TempData["SuccessMessage"] = "Müşteri başarıyla oluşturuldu.";

                if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("Customer.Email", ex.Message);
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating customer");
                ModelState.AddModelError("", "Müşteri oluşturulurken bir hata oluştu.");
                return View(model);
            }
        }

        public async Task<IActionResult> Edit(int id, string? returnUrl = null)
        {
            try
            {
                var customer = await _customerService.GetCustomerByIdAsync(id);
                if (customer == null)
                {
                    return NotFound();
                }

                var viewModel = new CustomerEditViewModel
                {
                    Customer = new UpdateCustomerDto
                    {
                        Id = customer.Id,
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        Email = customer.Email,
                        IsActive = customer.IsActive
                    },
                    ReturnUrl = returnUrl
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while loading customer for edit with id {CustomerId}", id);
                TempData["ErrorMessage"] = "Müşteri bilgileri yüklenirken bir hata oluştu.";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CustomerEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await _customerService.UpdateCustomerAsync(model.Customer);
                TempData["SuccessMessage"] = "Müşteri bilgileri başarıyla güncellendi.";

                if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }

                return RedirectToAction(nameof(Details), new { id = model.Customer.Id });
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("Customer.Email", ex.Message);
                return View(model);
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating customer with id {CustomerId}", model.Customer.Id);
                ModelState.AddModelError("", "Müşteri güncellenirken bir hata oluştu.");
                return View(model);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _customerService.DeleteCustomerAsync(id);
                if (result)
                {
                    TempData["SuccessMessage"] = "Müşteri başarıyla silindi.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Müşteri silinemedi.";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting customer with id {CustomerId}", id);
                TempData["ErrorMessage"] = "Müşteri silinirken bir hata oluştu.";
            }

            return RedirectToAction(nameof(Index));
        }
        // Partial View için AJAX endpoint
        [HttpGet]
        public async Task<IActionResult> SearchCustomers(string searchTerm)
        {
            try
            {
                var customers = await _customerService.SearchCustomersAsync(searchTerm ?? "");
                return PartialView("_CustomerListPartial", customers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while searching customers");
                return PartialView("_CustomerListPartial", new List<CustomerDto>());
            }
        }
    }
}
