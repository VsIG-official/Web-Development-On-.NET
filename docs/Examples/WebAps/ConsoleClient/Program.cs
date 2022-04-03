using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

// Nuget package Microsoft.AspNet.WebApi.Client

namespace ConsoleClient
{
       class Program
    {
        private const string path = @"http://localhost:44303/";
        static void Main(string[] args)

        {
            Product product = new Product() { Id = 300, Name = "NewName", Category = "NewCategory", Price = 5.7M };

            Console.WriteLine("Get");

            using (var client = new HttpClient())
            {
                //Console.WriteLine(path + "api/products"); 
                var response = client.GetAsync(@"https://localhost:44303/api/products").Result;
                var res =  response.Content.ReadAsStringAsync().Result;
                var rez2 = response.Content.ReadAsAsync<List<Product>>().Result;
                foreach (Product p in rez2)
                    Console.WriteLine(p.Id + p.Name + p.Category + p.Price);
            }

            Console.WriteLine("Post");

            using (var client = new HttpClient())
            {
                var response = client.PostAsJsonAsync(@"https://localhost:44303/api/products", product).Result;
                var statusCode = response.StatusCode.ToString();
                Console.WriteLine(statusCode.ToString());
            }

            Console.WriteLine("Get");

            using (var client = new HttpClient())
            {
                var response = client.GetAsync(@"https://localhost:44303/api/products").Result;
                var res = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(res);
            }

            Console.WriteLine("Delete");

            //using (var client = new HttpClient())
            //{
            //    var response = client.DeleteAsync(@"https://localhost:44303/api/products/300").Result;
            //    var statusCode = response.StatusCode.ToString();
            //    Console.WriteLine(statusCode.ToString());
            //}

            Console.WriteLine("Get");

            using (var client = new HttpClient())
            {
                var response = client.GetAsync(@"https://localhost:44303/api/products").Result;
                var res = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(res);
            }
            
            Console.ReadLine();
        }
    }
}
