using System;
using Lab3.DAL.Repositories.Abstract;

namespace Lab3.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IRoomRepository Rooms { get; }
        IOrderRepository Orders { get; }
        void Save();
    }
}
