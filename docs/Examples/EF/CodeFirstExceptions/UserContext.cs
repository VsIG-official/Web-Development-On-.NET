using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace CodeFirstExceptions
{
    class UserContext : DbContext
    {
        //static UserContext()
        //{
        //    Database.SetInitializer<UserContext>(new ContextInitializer());
        //}

        public UserContext(string connection) :
            base(connection)
        {
        }

        public DbSet<User> Users { get; set; }
    }

    //class ContextInitializer : DropCreateDatabaseAlways<UserContext>
    //{
    //    protected override void Seed(UserContext db)
    //    {
    //        User user1 = new User { Name = "Masha", Age = 15 };
    //        User user2 = new User { Name = "Dasha", Age = 16 };
            
    //        db.Users.Add(user1);
    //        db.Users.Add(user1);
    //        db.Users.Add(user2);
    //        db.SaveChanges();
    //    }
    //}
}
