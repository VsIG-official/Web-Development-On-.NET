using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CodeFirstExceptions
{

    class Program
    {
        static void Main(string[] args)
        {
            string path = ConfigurationSettings.AppSettings["DataDirectory"];
            AppDomain.CurrentDomain.SetData("DataDirectory", path);

            using (UserContext db = new UserContext("UserDB"))
            {
                User user1 = new User { Name = "Igor", Age = 18 };
                User user2 = new User { Name = "Tonya", Age = 9 };

                db.Users.Add(user1);
                db.Users.Add(user2);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Type t;
                    while (e != null)
                    {
                        t = e.GetType();
                        Console.WriteLine($" {t.Name} - {e.Message}");
                        e = e.InnerException;
                    }
                }

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
