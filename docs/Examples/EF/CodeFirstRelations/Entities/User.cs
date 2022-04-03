using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Friend> Friends { get; set; }

        public User()
        {
            Friends = new List<Friend>();
        }
    }
}

