using System;

namespace Lab3.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Users> Users { get; }
        IRepository<Rooms> Rooms { get; }
        IRepository<Order> Orders { get; }
        void Save();
    }
}
