using CargoManagementDataAccess.Entity.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoManagementApi.Repositories.CitiesRepository
{
    public interface ICityRepository
    {
        Task<City> GetById(int id);
        Task<IEnumerable<City>> GetAll();
        Task<bool> Create(City city);
        Task<bool> Update(int id, City city);
        Task<bool> Delete(int id);
    }

}
