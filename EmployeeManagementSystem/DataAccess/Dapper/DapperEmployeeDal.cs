using Entities;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataAccess.Interfaces;
using System.Data;

namespace DataAccess.Dapper
{
    public class DapperEmployeeDal : IEmployeeDal
    {
        private readonly IDbConnection _connection;

        public DapperEmployeeDal(IDbConnection connection)
        {
            _connection = connection;
        }

        public void Add(Employee employee)
        {
            _connection.Execute("INSERT INTO Employees ( AdSoyad, Departman, Email) VALUES (@AdSoyad, @Departman, @Email)", employee);
        }


        public void Delete(int id)
        {
            _connection.Execute("DELETE FROM Employees WHERE Id = @Id", new {Id = id});
        }

        public List<Employee> GetAll()
        {
            return _connection.Query<Employee>("SELECT * FROM Employees").ToList();
        }

        public Employee? GetById(int id)
        {
            return _connection.QueryFirstOrDefault<Employee>("SELECT * FROM Employees WHERE Id = @Id", new { Id = id });
            
        }

        public void Update(Employee employee)
        {
            _connection.Execute(
                "UPDATE Employees SET AdSoyad = @AdSoyad, Departman = @Departman, Email = @Email WHERE Id = @Id",
                new 
                {
                    employee.AdSoyad,
                    employee.Departman,
                    employee.Email,
                    employee.Id
                });
        }

    }
}
