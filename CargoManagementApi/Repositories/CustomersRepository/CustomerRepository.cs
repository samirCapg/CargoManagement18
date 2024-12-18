using CargoManagementDataAccess.Entity.Context;
using CargoManagementDataAccess.Entity.Models;
using System.Collections.Generic;
using System.Data.Entity; // Required for EF async methods
using System.Linq;
using System.Threading.Tasks;

namespace CargoManagementApi.Repositories.CustomerRepository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CargoManagementDbContext _context;

        public CustomerRepository(CargoManagementDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Customer customer)
        {
            if (customer != null)
            {
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetById(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<bool> Update(int Custid, Customer customer)
        {
            var CustInDb = await _context.Customers.FindAsync(Custid);
            if (CustInDb != null)
            {
                CustInDb.CustName = customer.CustName;
                CustInDb.CustAddress = customer.CustAddress;
                CustInDb.CustPhNo = customer.CustPhNo;
                CustInDb.CustEmail = customer.CustEmail;
                CustInDb.CustPassword = customer.CustPassword;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Customer>> SearchByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return await _context.Customers.ToListAsync();
            }
            return await _context.Customers
                .Where(c => c.CustName.Contains(name))
                .ToListAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var CustInDb = await _context.Customers.FindAsync(id);
            if (CustInDb != null)
            {
                _context.Customers.Remove(CustInDb);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
