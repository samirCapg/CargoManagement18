using CargoManagementDataAccess.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoManagementApi.Repositories.CustomerRepository
{
    public interface ICustomerRepository
    {
        Task<Customer> GetById(int id); // Returns a specific customer
        Task<IEnumerable<Customer>> GetAll(); // Returns all customers
        Task<bool> Create(Customer customer); // Returns true if the creation was successful
        Task<bool> Update(int id, Customer customer); // Returns true if the update was successful
        Task<bool> Delete(int id); // Returns true if the deletion was successful
        Task<IEnumerable<Customer>> SearchByName(string name); // Returns customers matching the name
    }

}
