using DAL.Entities.Abstract;
using DAL.Entities.Enums;

namespace DAL.Entities
{
    public class RoomEntity : BaseEntity
    {
        public Category Category { get; set; }
        public State State { get; set; }
        public decimal Price { get; set; }
    }
}
