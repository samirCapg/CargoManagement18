using CargoManagementDataAccess.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoManagementApi.Repositories.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetById(int id); // Asynchronous method to get an employee by ID
        Task<IEnumerable<Employee>> GetAll(); // Asynchronous method to get all employees
        Task<bool> Create(Employee employee); // Asynchronous method to create a new employee
        Task<bool> Update(int id, Employee employee); // Asynchronous method to update an existing employee
        Task<bool> Delete(int id); // Asynchronous method to delete an employee by ID
        Task<IEnumerable<Employee>> SearchByName(string name);
    }

}
