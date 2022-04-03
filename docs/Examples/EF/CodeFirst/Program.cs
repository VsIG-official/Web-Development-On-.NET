using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = ConfigurationSettings.AppSettings["DataDirectory"];
            AppDomain.CurrentDomain.SetData("DataDirectory", path);

            using (UserContext db = new UserContext("UserDB"))
            {
                User user1 = new User { Name = "Vera", Age = 18 };
                User user2 = new User { Name = "Tonya", Age = 9 };

                db.Users.Add(user1);
                db.Users.Add(user2);
                db.SaveChanges();

                var users = db.Users;
                foreach (User u in users)
                {
                    Console.WriteLine("{0}.{1} - {2}", u.Id, u.Name, u.Age);
                }

                Console.ReadKey();
            }
        }
    }
}
