using System.Collections.Generic;
using Lab3.DAL.Entities.Abstract;

namespace Lab3.DAL.Entities
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
