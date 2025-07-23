using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Services.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(IServiceManager manager, RoleManager<IdentityRole> roleManager)
        {
            _manager = manager;
            _roleManager = roleManager;
        }



        public IActionResult Index()
        {
            return View(_manager.AuthService.Roles);
        }

        public IActionResult Create()
        {            
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole roleName)
        {
            ModelState.AddModelError("", "Role name required");
            var role = new IdentityRole()
            {
                Id = roleName.Id,
                Name = roleName.Name,
                NormalizedName = roleName.Name.ToString().ToUpper(),
                ConcurrencyStamp = roleName.ConcurrencyStamp
            };

            var result = await _roleManager.CreateAsync(role);

            if (result.Succeeded)
                return RedirectToAction(nameof(Index));
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View();

        }


        public async Task<IActionResult> Delete(IdentityRole role)
        {
            var deleteRole = await _roleManager.FindByIdAsync(role.Id);
            await _roleManager.DeleteAsync(deleteRole);
            return RedirectToAction(nameof(Index));
            
        }

        public async Task<IActionResult> Update(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            return View(role);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(IdentityRole role)
        {
            IdentityRole result = await _roleManager.FindByIdAsync(role.Id);
            result.Name = role.Name;
            result.NormalizedName = role.Name.ToUpper();
            await _roleManager.UpdateAsync(result);
            return RedirectToAction(nameof(Index));
            
            
        }
    }
}