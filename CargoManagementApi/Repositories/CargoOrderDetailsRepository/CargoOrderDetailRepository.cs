using CargoManagementDataAccess.Entity.Context;
using CargoManagementDataAccess.Entity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;

namespace CargoManagementApi.Repositories.CargoOrderDetailsRepository
{
    public class CargoOrderDetailRepository : ICargoOrderDetailRepository
    {
        private readonly CargoManagementDbContext _context;

        public CargoOrderDetailRepository(CargoManagementDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(CargoOrderDetail orderDetail)
        {
            if (orderDetail != null)
            {
                _context.CargoOrderDetails.Add(orderDetail);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var orderDetailInDb = await _context.CargoOrderDetails.FindAsync(id);
            if (orderDetailInDb != null)
            {
                _context.CargoOrderDetails.Remove(orderDetailInDb);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<CargoOrderDetail>> GetAll()
        {
            return await _context.CargoOrderDetails.ToListAsync();
        }

        public async Task<CargoOrderDetail> GetById(int id)
        {
            return await _context.CargoOrderDetails.FindAsync(id);
        }

        public async Task<bool> Update(int id, CargoOrderDetail orderDetail)
        {
            var orderDetailInDb = await _context.CargoOrderDetails.FindAsync(id);
            if (orderDetailInDb != null)
            {
                orderDetailInDb.OrderDate = orderDetail.OrderDate;
                orderDetailInDb.OrderId = orderDetail.OrderId;
                orderDetailInDb.ReceiverName = orderDetail.ReceiverName;
                orderDetailInDb.CargoStatus = orderDetail.CargoStatus;
                orderDetailInDb.CargoStatusId = orderDetail.CargoStatusId;
                orderDetailInDb.CustId = orderDetail.CustId;
                orderDetailInDb.CargoType = orderDetail.CargoType;
                orderDetailInDb.CargoTypeId = orderDetail.CargoTypeId;
                orderDetailInDb.City = orderDetail.City;
                orderDetailInDb.CityId = orderDetail.CityId;

                await _context.SaveChangesAsync();
                return true;
                
            }
            return false;
        }
    }
}
