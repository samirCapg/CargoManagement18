using CargoManagementDataAccess.Entity.Context;
using CargoManagementDataAccess.Entity.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace CargoManagementApi.Repositories.ProductsRepository
{
    public class CargoTypeRepository : ICargoTypeRepository
    {
        private readonly CargoManagementDbContext _context;

        public CargoTypeRepository(CargoManagementDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(CargoType cargoType)
        {
            if (cargoType != null)
            {
                _context.CargoTypes.Add(cargoType);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var cargoTypeInDb = await _context.CargoTypes.FindAsync(id);
            if (cargoTypeInDb != null)
            {
                _context.CargoTypes.Remove(cargoTypeInDb);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<CargoType>> GetAll()
        {
            return await _context.CargoTypes.ToListAsync();
        }

        public async Task<CargoType> GetById(int id)
        {
            return await _context.CargoTypes.FindAsync(id);
        }

        public async Task<bool> Update(int id, CargoType cargoType)
        {
            var cargoTypeInDb = await _context.CargoTypes.FindAsync(id);
            if (cargoTypeInDb != null)
            {
                cargoTypeInDb.Name = cargoType.Name;
                cargoTypeInDb.Price = cargoType.Price;
                cargoTypeInDb.Weight = cargoType.Weight;
                cargoTypeInDb.ExtraPrice = cargoType.ExtraPrice;
                cargoTypeInDb.ExtraWeight = cargoType.ExtraWeight;

                _context.Entry(cargoTypeInDb).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
