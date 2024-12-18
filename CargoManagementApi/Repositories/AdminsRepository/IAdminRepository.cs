using CargoManagementDataAccess.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CargoManagementApi.Repositories.AdminRepository
{
    public interface IAdminRepository
    {
        Task<Admin> GetById(int id); // Returns a specific admin
        Task<IEnumerable<Admin>> GetAll(); // Returns all admins
        Task<bool> Create(Admin admin); // Returns true if the creation was successful
        Task<bool> Update(int id, Admin admin); // Returns true if the update was successful
        Task<bool> Delete(int id); // Returns true if the deletion was successful

    }
}
