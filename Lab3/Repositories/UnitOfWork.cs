using System;
using Lab3.DAL.Entities;
using Lab3.DAL.EntityFramework;
using Lab3.DAL.Interfaces;

namespace Lab3.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HotelContext _db;
        private UserRepository _userRepository;
        private RoomRepository _roomRepository;
        private OrderRepository _orderRepository;
        
        private bool _disposed = false;

        public UnitOfWork(string connectionString)
        {
            _db = new HotelContext(connectionString);
        }
        public IRepository<User> Users
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_db);
                }

                // TODO
                return (IRepository<User>)_userRepository;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (_orderRepository == null)
                {
                    _orderRepository = new OrderRepository(_db);
                }

                // TODO
                return (IRepository<Order>)_orderRepository;
            }
        }

        public IRepository<Room> Rooms
        {
            get
            {
                if (_roomRepository == null)
                {
                    _roomRepository = new RoomRepository(_db);
                }

                // TODO
                return (IRepository<Room>)_roomRepository;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
