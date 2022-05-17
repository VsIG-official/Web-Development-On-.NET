using System.Collections.Generic;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories.Abstract
{
    public interface IOrderRepository : IRepository<OrderEntity>
    {
        List<RoomEntity> GetAllRoomsInOrderById(int id);
    }
}
