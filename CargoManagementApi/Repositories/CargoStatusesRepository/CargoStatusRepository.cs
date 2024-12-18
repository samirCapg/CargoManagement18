using CargoManagementDataAccess.Entity.Context;
using CargoManagementDataAccess.Entity.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace CargoManagementApi.Repositories.CargoStatusesRepository
{
    public class CargoStatusRepository : ICargoStatusRepository
    {
        private readonly CargoManagementDbContext _context;

        public CargoStatusRepository(CargoManagementDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(CargoStatus cargoStatus)
        {
            if (cargoStatus != null)
            {
                _context.cargoStatuses.Add(cargoStatus);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var statusInDb = await _context.cargoStatuses.FindAsync(id);
            if (statusInDb != null)
            {
                _context.cargoStatuses.Remove(statusInDb);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<CargoStatus>> GetAll()
        {
            return await _context.cargoStatuses.ToListAsync();
        }

        public async Task<CargoStatus> GetById(int id)
        {
            return await _context.cargoStatuses.FindAsync(id);
        }

        public async Task<bool> Update(int id, CargoStatus cargoStatus)
        {
            var statusInDb = await _context.cargoStatuses.FindAsync(id);
            if (statusInDb != null)
            {
                statusInDb.StatusName = cargoStatus.StatusName;
                _context.Entry(statusInDb).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
