using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories.Abstract
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        UserEntity GetByLogin(string login);
    }
}
