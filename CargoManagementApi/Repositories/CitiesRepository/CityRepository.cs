using CargoManagementDataAccess.Entity.Context;
using CargoManagementDataAccess.Entity.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace CargoManagementApi.Repositories.CitiesRepository
{
    public class CityRepository : ICityRepository
    {
        private readonly CargoManagementDbContext _context;

        public CityRepository(CargoManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<City>> GetAll()
        {
            return await _context.Cities.ToListAsync();
        }

        public async Task<City> GetById(int id)
        {
            return await _context.Cities.FindAsync(id);
        }

        public async Task<bool> Create(City city)
        {
            if (city != null)
            {
                _context.Cities.Add(city);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> Update(int id, City city)
        {
            var cityInDb = await _context.Cities.FindAsync(id);
            if (cityInDb != null)
            {
                cityInDb.CityName = city.CityName;
                cityInDb.Pincode = city.Pincode;
                cityInDb.Country = city.Country;

                _context.Entry(cityInDb).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var cityInDb = await _context.Cities.FindAsync(id);
            if (cityInDb != null)
            {
                _context.Cities.Remove(cityInDb);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
