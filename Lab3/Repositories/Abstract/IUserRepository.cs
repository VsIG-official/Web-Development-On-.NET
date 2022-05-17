using Lab3.DAL.Entities;
using Lab3.DAL.Interfaces;

namespace Lab3.DAL.Repositories.Abstract
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        UserEntity GetByLogin(string login);
    }
}
