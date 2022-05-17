﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Lab3.DAL.Entities;
using Lab3.DAL.EntityFramework;
using Lab3.DAL.Interfaces;

namespace Lab3.DAL.Repositories
{
    public class UserRepository : IRepository<UserEntity>
    {
        private readonly HotelContext _db;

        public UserRepository(HotelContext context)
        {
            _db = context;
        }

        public UserEntity Get(int id)
        {
            return _db.Users.Find(id);
        }

        public void Create(UserEntity user)
        {
            _db.Users.Add(user);
        }

        public void Update(UserEntity user)
        {
            _db.Entry(user).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            UserEntity user = _db.Users.Find(id);
            if (user != null)
            {
                _db.Users.Remove(user);
            }
        }
        
        public IEnumerable<UserEntity> GetAll()
        {
            return _db.Users;
        }
        
        public IEnumerable<UserEntity> Find(Func<UserEntity, bool> predicate)
        {
            return _db.Users.Where(predicate).ToList();
        }
    }
}
