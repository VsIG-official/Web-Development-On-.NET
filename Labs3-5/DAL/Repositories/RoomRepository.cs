using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Entities;
using DAL.Entities.Enums;
using DAL.EntityFramework;
using DAL.Repositories.Abstract;

namespace DAL.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelContext _db;

        public RoomRepository(HotelContext context)
        {
            _db = context;
        }

        public RoomEntity Get(int id)
        {
            return _db.Rooms.Find(id);
        }

        public void Create(RoomEntity room)
        {
            _db.Rooms.Add(room);
        }

        public void Update(RoomEntity room)
        {
            _db.Entry(room).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            RoomEntity room = _db.Rooms.Find(id);
            if (room != null)
            {
                _db.Rooms.Remove(room);
            }
        }

        public IEnumerable<RoomEntity> GetAll()
        {
            return _db.Rooms;
        }

        public IEnumerable<RoomEntity> Find(Func<RoomEntity, bool> predicate)
        {
            return _db.Rooms.Where(predicate).ToList();
        }

        public List<RoomEntity> FindAllRoomsByCategory(Category category)
        {
            return _db.Rooms.Where(r => r.Category == category).ToList();
        }
    }
}
