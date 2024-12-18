using CargoManagementDataAccess.Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoManagementApi.Repositories.CargoStatusesRepository
{
    public interface ICargoStatusRepository
    {
        Task<CargoStatus> GetById(int id);
        Task<IEnumerable<CargoStatus>> GetAll();
        Task<bool> Create(CargoStatus cargoStatus);
        Task<bool> Update(int id, CargoStatus cargoStatus);
        Task<bool> Delete(int id);
    }
}
