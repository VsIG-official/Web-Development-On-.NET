using System.Collections.Generic;
using Lab3.DAL.Entities;
using Lab3.DAL.Interfaces;

namespace Lab3.DAL.Repositories.Abstract
{
    public interface IOrderRepository : IRepository<OrderEntity>
    {
        List<RoomEntity> GetAllRoomsInOrderById(int id);
    }
}
