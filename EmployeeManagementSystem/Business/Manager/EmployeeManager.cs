using Business.Services;
using DataAccess.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Manager
{
    public class EmployeeManager : IEmployeeService
    {
        private readonly IEmployeeDal _employeeDal;
        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        public void CreateEmployee(Employee employee)
        {
            _employeeDal.Add(employee);
        }

        public void DeleteEmployee(int id)
        {
            _employeeDal.Delete(id);
        }

        public List<Employee> GetAllEmployee() => _employeeDal.GetAll();


        public Employee? GetOneEmployee(int id)
        {
            return (_employeeDal.GetById(id));
        }

        public void UpdateEmployee(Employee employee)
        {
            _employeeDal.Update(employee);
        }
    }
}
