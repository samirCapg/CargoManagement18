using CargoManagementDataAccess.Entity.Context;
using CargoManagementDataAccess.Entity.Models;
using System.Collections.Generic;
using System.Data.Entity; // For async EF methods
using System.Linq;
using System.Threading.Tasks;

namespace CargoManagementApi.Repositories.EmployeeRepository
{


    namespace CargoManagementApi.Repositories.EmployeeRepository
    {
        public class EmployeeRepository : IEmployeeRepository
        {
            private readonly CargoManagementDbContext _context;

            public EmployeeRepository(CargoManagementDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Create(Employee employee)
            {
                if (employee != null)
                {
                    _context.Employees.Add(employee);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }

            public async Task<IEnumerable<Employee>> GetAll()
            {
                return await _context.Employees.ToListAsync();
            }

            public async Task<Employee> GetById(int id)
            {
                return await _context.Employees.FindAsync(id);
            }

            public async Task<bool> Update(int id, Employee emp)
            {
                var employee = await _context.Employees.FindAsync(id);
                if (employee != null)
                {
                    employee.UserName = emp.UserName;
                    employee.EmpName = emp.EmpName;
                    employee.EmpPhNo = emp.EmpPhNo;
                    employee.EmpEmail = emp.EmpEmail;
                    employee.Password = emp.Password;
                    // IsApproved is not updated
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }


            public async Task<IEnumerable<Employee>> SearchByName(string name)
            {
                if (string.IsNullOrEmpty(name))
                {
                    return await _context.Employees.ToListAsync();
                }
                return await _context.Employees
                    .Where(c => c.EmpName.Contains(name))
                    .ToListAsync();
            }
            public async Task<bool> Delete(int id)
            {
                var emp = await _context.Employees.FindAsync(id);
                if (emp != null)
                {
                    _context.Employees.Remove(emp);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
        }
    }

}