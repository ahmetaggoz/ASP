using Business.Services;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var values = _service.GetAllEmployee();
            return View(values);
        }
        
        public IActionResult Insert()
        {
            return View(new Employee());
        }
        [HttpPost]
        public IActionResult Insert(Employee employee)
        {
            _service.CreateEmployee(employee);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _service.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var value = _service.GetOneEmployee(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Update(Employee employee)
        {
            _service.UpdateEmployee(employee);
            return RedirectToAction("Index");
        }
       
    }
}
