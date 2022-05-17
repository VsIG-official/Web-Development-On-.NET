using System.Collections.Generic;
using DAL.Entities;
using DAL.Entities.Enums;
using DAL.Interfaces;

namespace DAL.Repositories.Abstract
{
    public interface IRoomRepository : IRepository<RoomEntity>
    {
        List<RoomEntity> FindAllRoomsByCategory(Category category);
    }
}
