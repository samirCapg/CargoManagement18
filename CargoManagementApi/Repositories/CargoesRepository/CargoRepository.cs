using CargoManagementDataAccess.Entity.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System;
using System.ComponentModel.DataAnnotations;
using CargoManagementDataAccess.Entity.Context;

namespace CargoManagementApi.Repositories
{
    public class CargoRepository : ICargoRepository
    {
        private readonly CargoManagementDbContext _context;

        public CargoRepository(CargoManagementDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cargo>> GetAllCargo()
        {
            return await _context.Cargoes.Include(c => c.CargoType).ToListAsync();
        }

        public async Task<Cargo> GetCargoById(int id)
        {
            return await _context.Cargoes.Include(c => c.CargoType).FirstOrDefaultAsync(c => c.CargoId == id);
        }

        public async Task Create(Cargo cargo)
        {
            // Validate Cargo model
            var validationResults = new List<ValidationResult>();
            if (!Validator.TryValidateObject(cargo, new ValidationContext(cargo), validationResults, true))
            {
                throw new ValidationException("Cargo model is invalid.");
            }

            _context.Cargoes.Add(cargo);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Update(int id, Cargo cargo)
        {
            var existingCargo = await _context.Cargoes.FindAsync(id);
            if (existingCargo != null)
            {
                // Validate Cargo model
                var validationResults = new List<ValidationResult>();
                if (!Validator.TryValidateObject(cargo, new ValidationContext(cargo), validationResults, true))
                {
                    throw new ValidationException("Cargo model is invalid.");
                }

                // Update Cargo properties
                existingCargo.CargoName = cargo.CargoName;
                existingCargo.Place = cargo.Place;
                existingCargo.OrderDate = cargo.OrderDate;
                existingCargo.Price = cargo.Price;
                existingCargo.Weight = cargo.Weight;
                existingCargo.CargoTypeId = cargo.CargoTypeId;

                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var cargo = await _context.Cargoes.FindAsync(id);
            if (cargo != null)
            {
                _context.Cargoes.Remove(cargo);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
