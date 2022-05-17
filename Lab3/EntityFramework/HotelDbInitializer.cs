using System.Data.Entity;
using Lab3.DAL.Entities;

namespace Lab3.DAL.EntityFramework
{
    public class HotelDbInitializer :
        DropCreateDatabaseIfModelChanges<HotelContext>
    {
        protected override void Seed(HotelContext db)
        {
            db.Users.Add(new UserEntity
            {
                Name = "Валентин",
                Email = "RandomEmail@gmail.com",
                Login = "RandomLogin",
                Password = "123123"
            });
            db.Users.Add(new UserEntity
            {
                Name = "Микита",
                Email = "MykytaEmail@gmail.com",
                Login = "MykytaLogin",
                Password = "123456"
            });
            db.Rooms.Add(new RoomEntity
            {
                Category = Category.Small,
                State = State.Free,
                Price = 100
            });
            db.Rooms.Add(new RoomEntity
            {
                Category = Category.Large,
                State = State.InUse,
                Price = 1000
            });
            db.SaveChanges();
        }
    }
}
