using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Entities;
using DAL.EntityFramework;
using DAL.Repositories.Abstract;

namespace DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly HotelContext _db;

        public OrderRepository(HotelContext context)
        {
            _db = context;
        }

        public IEnumerable<OrderEntity> GetAll()
        {
            return _db.Orders.Include(order => order.Id);
        }
        
        public OrderEntity Get(int id)
        {
            return _db.Orders.Find(id);
        }

        public void Create(OrderEntity order)
        {
            _db.Orders.Add(order);
        }

        public void Update(OrderEntity order)
        {
            _db.Entry(order).State = EntityState.Modified;
        }
        public IEnumerable<OrderEntity> Find(Func<OrderEntity, bool> predicate)
        {
            return _db.Orders.Include(order => order.Id)
                .Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            OrderEntity order = _db.Orders.Find(id);
            if (order != null)
            {
                _db.Orders.Remove(order);
            }
        }

        public List<RoomEntity> GetAllRoomsInOrderById(int id)
        {
            return Get(id).Rooms.ToList();
        }
    }
}
