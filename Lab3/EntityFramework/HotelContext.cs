using System.Data.Entity;
using Lab3.DAL.Entities;

namespace Lab3.DAL.EntityFramework
{
    public class HotelContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoomEntity> Rooms { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }

        public HotelContext() : base("DBConnection")
        {
            Database.Initialize(true);
        }

        public HotelContext(string connectionString)
            : base(connectionString) { }
    }
}
