using CargoManagementDataAccess.Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoManagementApi.Repositories.CargoOrderDetailsRepository
{
    public interface ICargoOrderDetailRepository
    {
        Task<CargoOrderDetail> GetById(int id);
        Task<IEnumerable<CargoOrderDetail>> GetAll();
        Task<bool> Create(CargoOrderDetail orderDetail);
        Task<bool> Update(int id, CargoOrderDetail orderDetail);
        Task<bool> Delete(int id);
    }
}
