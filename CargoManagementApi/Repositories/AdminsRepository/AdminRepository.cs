using CargoManagementDataAccess.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


using CargoManagementDataAccess.Entity.Context;
using System.Data.Entity;

namespace CargoManagementApi.Repositories.AdminRepository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly CargoManagementDbContext _context;
        public AdminRepository(CargoManagementDbContext context)
        {
            _context = context;
        }



        //Get all admin 
        public async Task<IEnumerable<Admin>> GetAll()
        {
            return await _context.Admins.ToListAsync();
        }

        //Get admin by Id
        public async Task<Admin> GetById(int id)
        {
            var admin = await _context.Admins.FindAsync(id);
            if (admin != null)
            {
                return admin;

            }
            return null;
        }

        //Create admin
        public async Task<bool> Create(Admin admin)
        {
            if (admin != null)
            {
                _context.Admins.Add(admin);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        
        public async Task<bool> Update(int id, Admin admin)
        {
            var adminInDb = await _context.Admins.FindAsync(id);
            if (adminInDb != null)
            {
            // Update fields
                adminInDb.UserName = admin.UserName;
                adminInDb.Name = admin.Name;
                adminInDb.Email = admin.Email;
                adminInDb.Password = admin.Password;

                // Save changes
                await _context.SaveChangesAsync();
                return true;
            }

            return false; // Admin with the given ID not found
        }

        public async Task<bool> Delete(int id)
        {
            var adminInDb = await _context.Admins.FindAsync(id); // Find admin by ID
            if (adminInDb != null)
            {
                _context.Admins.Remove(adminInDb); // Remove the admin
                await _context.SaveChangesAsync(); // Save changes to the database
                return true; // Return the deleted admin
            }
            return false; // Admin not found
        }
    }
}