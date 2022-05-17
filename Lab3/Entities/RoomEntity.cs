using Lab3.DAL.Entities.Abstract;
using Lab3.DAL.Entities.Enums;

namespace Lab3.DAL.Entities
{
    public class RoomEntity : BaseEntity
    {
        public Category Category { get; set; }
        public State State { get; set; }
        public decimal Price { get; set; }
    }
}
