using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Lab3.DAL.Entities;
using Lab3.DAL.EntityFramework;

namespace Lab3.DAL.Repositories
{
    public class UserRepository
    {
        private readonly HotelContext _db;

        public UserRepository(HotelContext context)
        {
            _db = context;
        }

        public User Get(int id)
        {
            return _db.Users.Find(id);
        }

        public void Create(User user)
        {
            _db.Users.Add(user);
        }

        public void Update(User user)
        {
            _db.Entry(user).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            User user = _db.Users.Find(id);
            if (user != null)
            {
                _db.Users.Remove(user);
            }
        }
        
        public IEnumerable<User> GetAll()
        {
            return _db.Users;
        }
        
        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
            return _db.Users.Where(predicate).ToList();
        }
    }
}
