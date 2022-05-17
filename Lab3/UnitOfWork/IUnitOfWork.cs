using System;
using Lab3.DAL.Entities;

namespace Lab3.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<UserEntity> Users { get; }
        IRepository<RoomEntity> Rooms { get; }
        IRepository<OrderEntity> Orders { get; }
        void Save();
    }
}
