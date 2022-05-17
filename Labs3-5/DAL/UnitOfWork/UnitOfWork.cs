using System;
using DAL.EntityFramework;
using DAL.Interfaces;
using DAL.Repositories.Abstract;

namespace DAL.Repositories
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
        
        public IUserRepository Users
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_db);
                }

                return _userRepository;
            }
        }

        public IOrderRepository Orders
        {
            get
            {
                if (_orderRepository == null)
                {
                    _orderRepository = new OrderRepository(_db);
                }

                return _orderRepository;
            }
        }

        public IRoomRepository Rooms
        {
            get
            {
                if (_roomRepository == null)
                {
                    _roomRepository = new RoomRepository(_db);
                }

                return _roomRepository;
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
