using BLL.Entities.Abstract;

namespace BLL.Entities
{
    public class UserDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
