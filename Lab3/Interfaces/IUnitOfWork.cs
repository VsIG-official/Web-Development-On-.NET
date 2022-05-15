using System;
using Lab3.DAL.Entities;

namespace Lab3.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<Room> Rooms { get; }
        IRepository<Order> Orders { get; }
        void Save();
    }
}
