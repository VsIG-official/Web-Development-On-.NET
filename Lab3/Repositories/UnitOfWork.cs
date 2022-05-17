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
        public IRepository<UserEntity> Users
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_db);
                }

                // TODO
                return (IRepository<UserEntity>)_userRepository;
            }
        }

        public IRepository<OrderEntity> Orders
        {
            get
            {
                if (_orderRepository == null)
                {
                    _orderRepository = new OrderRepository(_db);
                }

                // TODO
                return (IRepository<OrderEntity>)_orderRepository;
            }
        }

        public IRepository<RoomEntity> Rooms
        {
            get
            {
                if (_roomRepository == null)
                {
                    _roomRepository = new RoomRepository(_db);
                }

                // TODO
                return (IRepository<RoomEntity>)_roomRepository;
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
