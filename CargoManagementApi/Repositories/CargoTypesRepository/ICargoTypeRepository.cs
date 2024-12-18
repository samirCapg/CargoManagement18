using CargoManagementDataAccess.Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoManagementApi.Repositories.ProductsRepository
{
    public interface ICargoTypeRepository
    {
        Task<CargoType> GetById(int id);
        Task<IEnumerable<CargoType>> GetAll();
        Task<bool> Create(CargoType cargoType);
        Task<bool> Update(int id, CargoType cargoType);
        Task<bool> Delete(int id);
    }
}
