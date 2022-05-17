using System;
using DAL.Repositories.Abstract;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IRoomRepository Rooms { get; }
        IOrderRepository Orders { get; }
        void Save();
    }
}
