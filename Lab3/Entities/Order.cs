using System;
using System.Collections.Generic;

namespace Lab3.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public decimal Sum { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
