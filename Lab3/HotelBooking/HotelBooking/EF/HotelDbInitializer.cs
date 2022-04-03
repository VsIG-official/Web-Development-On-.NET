using System.Data.Entity;
using HotelBooking.DAL.Entities;

namespace HotelBooking.DAL.EF;

public class HotelDbInitializer : DropCreateDatabaseIfModelChanges<HotelContext>
{
    protected override void Seed(HotelContext db)
    {
        db.Hotels.Add(new Hotel
        {
            Id = 1,
            Name = "Random Hotel",
            Address = "Random Address",
            Description = "Random Description"
        });
        db.Rooms.Add(new Room
        {
            Id = 1,
            HotelId = 1,
            Name = "Random Room #1",
            Price = 100,
            Type = 1,
            Capacity = 1,
        });
        db.Users.Add(new User
        {
            Id = 1,
            FirstName = "Random First Name",
            LastName = "Random Last Name",
            Email = "Random Email",
        });
        db.Orders.Add(new Order
        {
            Id = 1,
            UserId = 1,
            HotelId = 1,
            RoomId = 1,
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(1),
            Price = 100,
        });
        db.SaveChanges();
    }
}
