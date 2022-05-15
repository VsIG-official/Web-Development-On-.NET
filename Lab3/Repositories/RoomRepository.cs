using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Lab3.DAL.Entities;
using Lab3.DAL.EntityFramework;

namespace Lab3.DAL.Repositories
{
    public class RoomRepository
    {
        private readonly HotelContext _db;

        public RoomRepository(HotelContext context)
        {
            _db = context;
        }

        public Room Get(int id)
        {
            return _db.Rooms.Find(id);
        }

        public void Create(Room room)
        {
            _db.Rooms.Add(room);
        }

        public void Update(Room room)
        {
            _db.Entry(room).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Room room = _db.Rooms.Find(id);
            if (room != null)
            {
                _db.Rooms.Remove(room);
            }
        }

        public IEnumerable<Room> GetAll()
        {
            return _db.Rooms;
        }

        public IEnumerable<Room> Find(Func<Room, bool> predicate)
        {
            return _db.Rooms.Where(predicate).ToList();
        }
    }
}
