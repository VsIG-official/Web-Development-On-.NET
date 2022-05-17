using System.Collections.Generic;
using DAL.Entities.Abstract;

namespace DAL.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public virtual ICollection<OrderEntity> Orders { get; set; }
    }
}
