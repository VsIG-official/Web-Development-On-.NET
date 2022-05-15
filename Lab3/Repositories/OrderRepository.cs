using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Lab3.DAL.Entities;
using Lab3.DAL.EntityFramework;

namespace Lab3.DAL.Repositories
{
    public class OrderRepository
    {
        private readonly HotelContext _db;

        public OrderRepository(HotelContext context)
        {
            _db = context;
        }

        public IEnumerable<Order> GetAll()
        {
            return _db.Orders.Include(order => order.Id);
        }
        
        public Order Get(int id)
        {
            return _db.Orders.Find(id);
        }

        public void Create(Order order)
        {
            _db.Orders.Add(order);
        }

        public void Update(Order order)
        {
            _db.Entry(order).State = EntityState.Modified;
        }
        public IEnumerable<Order> Find(Func<Order, bool> predicate)
        {
            return _db.Orders.Include(order => order.Id)
                .Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Order order = _db.Orders.Find(id);
            if (order != null)
            {
                _db.Orders.Remove(order);
            }
        }
    }
}
