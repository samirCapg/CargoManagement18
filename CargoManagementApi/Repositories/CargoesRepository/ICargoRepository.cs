using System.Collections.Generic;
using System.Threading.Tasks;
using CargoManagementDataAccess.Entity.Models;

namespace CargoManagementApi.Repositories
{
    public interface ICargoRepository
    {
        Task<List<Cargo>> GetAllCargo();
        Task<Cargo> GetCargoById(int id);
        Task Create(Cargo cargo);
        Task<bool> Update(int id, Cargo cargo);
        Task<bool> Delete(int id);
    }
}
