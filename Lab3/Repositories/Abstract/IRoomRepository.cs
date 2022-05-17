using System.Collections.Generic;
using Lab3.DAL.Entities;
using Lab3.DAL.Entities.Enums;
using Lab3.DAL.Interfaces;

namespace Lab3.DAL.Repositories.Abstract
{
    public interface IRoomRepository : IRepository<RoomEntity>
    {
        List<RoomEntity> FindAllRoomsByCategory(Category category);
    }
}
