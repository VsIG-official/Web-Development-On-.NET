using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFwork1
{
    class Program
    {
        static void Main(string[] args)
        {
            RegionsTerritories();
            AddRegion();
            Regions();
            UpdateRegion();
            Regions();
            DeleteRegion();
            Regions();
            // Call StoredProcedure ProductCountInCategory
            Categories();
        }

        static void Categories()
        {
            using (var db = new productContext())
            {
                var query1 = from b in db.Categories
                             orderby b.CategoryID
                             select b;

                foreach (var item in query1)
                {
                    Console.Write(item.CategoryID + " " + item.CategoryName);
                    Console.WriteLine();
                }
            }

            Console.WriteLine();

            Console.WriteLine("enter category name from list: ");
            string category = Console.ReadLine();
            System.Data.Objects.ObjectParameter param = new System.Data.Objects.ObjectParameter("productcount", 0);
            using (var db = new productContext())
            {
                db.ProductCountInCategory(category, param);
                int i = (int)param.Value;
                Console.WriteLine("Count product in category {0} is {1}", category, i);
            }
        }

        static void RegionsTerritories()
        {
            using (var db = new productContext())
            {
                // НАВЕСТИ НА query0 во время отладки - немедленная загрузка (Include("Territories"))
                var query0 = from b in db.Regions.Include("Territories")
                             orderby b.RegionID
                             select b;

                Console.WriteLine(query0.ToString());

                // НАВЕСТИ НА query1 во время отладки - ленивая загрузка (Lazy loading)
                var query1 = from b in db.Regions
                             orderby b.RegionID
                             select b;
                Console.WriteLine();
                Console.WriteLine(query1.ToString());
                               
                foreach (var item in query1)
                {
                    Console.WriteLine(item.RegionID + " " + item.RegionDescription);
                    foreach (var territory in item.Territories)
                    {
                        Console.WriteLine("-----{0} {1}", territory.TerritoryID, territory.TerritoryDescription);
                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
        }

        static void Regions()
        {
            using (var db = new productContext())
            {
                // НАВЕСТИ НА query1 во время отладки - отобразится лежащий в основе query1 SQL-оператор
                var query1 = from r in db.Regions
                             let ts = from t in r.Territories select (t)
                             //where r.RegionID < 100 && ts.Count() >= 0
                             orderby r.RegionID
                             select new
                             {
                                 RegionID = r.RegionID,
                                 RegionDescription = r.RegionDescription,
                                 RegionCountTerritories = ts.Count()
                             };

                foreach (var item in query1)
                { 
                    Console.WriteLine("{0:D3} {1} {2}", item.RegionID, item.RegionDescription, item.RegionCountTerritories);
                  }
                Console.WriteLine();
            }
        }

        static void AddRegion()
        {
            Console.WriteLine("Add region:");
            Console.Write("enter region id (integer): ");
            int regionID = Convert.ToInt32(Console.ReadLine());
            Console.Write("enter region description (string): ");
            string regionDescription = Console.ReadLine();

            using (var db = new productContext())
            {
                Region region = db.Regions.FirstOrDefault(r => (r.RegionID == regionID) || (r.RegionDescription == regionDescription));
                if (region != null)
                    Console.WriteLine("such region exist!");
                else
                {
                    int i;
                    i = db.Regions.Count();
                    Console.WriteLine($"i = {i}");
                    try
                    {
                        region = new Region { RegionID = regionID, RegionDescription = regionDescription };
                        db.Regions.Add(region);
                        //Region newregion = new Region { RegionID = regionID, RegionDescription = "fhkfbklfjlkfjglf" };
                        //db.Regions.Add(newregion);
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("error, region isn't added!");
                    }
                    i = db.Regions.Count();
                    Console.WriteLine($"i = {i}");
                    Console.WriteLine("region is added!");

                }
            }
        }

        static void UpdateRegion()
        {
            Console.WriteLine("Update region:");
            Console.Write("enter region id (integer) to find: ");
            int regionID = Convert.ToInt32(Console.ReadLine());
            Console.Write("enter new region description (string): ");
            string regionDescription = Console.ReadLine();

            using (var db = new productContext())
            {
                Region region = db.Regions.FirstOrDefault(r => r.RegionID == regionID );
                if (region == null)
                    Console.WriteLine("such region doesn't exist! no update");
                else
                {
                    region.RegionDescription = regionDescription;
                    db.Entry(region).State = System.Data.EntityState.Modified;
                    db.SaveChanges();
                    Console.WriteLine("region is updated!");
                }
            }
        }

        static void DeleteRegion()
        {
            Console.WriteLine("Delete region:");
            Console.Write("enter region id (integer) to find: ");
            int regionID = Convert.ToInt32(Console.ReadLine());
            
            using (var db = new productContext())
            {
                Region region = db.Regions.FirstOrDefault(r => r.RegionID == regionID);
                if (region == null)
                    Console.WriteLine("such region doesn't exist! no delete");
                else
                {
                    db.Regions.Remove(region);
                    db.SaveChanges();
                    Console.WriteLine("region is deleted!");
                }
            }
        }
    }
}
