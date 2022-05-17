using System;
using System.Collections.Generic;
using Lab3.DAL.Entities.Abstract;

namespace Lab3.DAL.Entities
{
    public class OrderEntity : BaseEntity
    {
        public int UserId { get; set; }
        public ICollection<RoomEntity> Rooms { get; set; }
        public decimal Sum { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
