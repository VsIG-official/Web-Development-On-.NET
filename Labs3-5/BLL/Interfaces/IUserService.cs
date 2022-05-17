using BLL.Entities;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        void AddUser(UserDTO user);
        void UpdateUser(UserDTO user);
        UserDTO GetUserById(int id);
        void DeleteUserById(int id);
    }
}
