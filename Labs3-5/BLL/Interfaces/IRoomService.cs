using System.Collections.Generic;
using BLL.Entities;

namespace BLL.Interfaces
{
    public interface IRoomService
    {
        void AddRoom(RoomDTO room);
        void UpdateRoom(RoomDTO room);
        RoomDTO GetRoomById(int id);
        void DeleteRoomById(int id);
        IEnumerable<RoomDTO> GetRooms();
    }
}
