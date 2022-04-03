using HotelBooking.DAL.Entities;
using System.Data.Entity;

namespace HotelBooking.DAL.EF;

public class HotelContext : DbContext
{
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders{ get; set; }

    static HotelContext()
    {
        Database.SetInitializer(new HotelDbInitializer());
    }
}
