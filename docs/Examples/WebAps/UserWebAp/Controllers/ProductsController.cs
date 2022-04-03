using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UserWebAp.Models;

namespace UserWebAp.Controllers
{
    public class ProductsController : ApiController
    {
        static List<Product> products = new List<Product>()
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        };

        public IEnumerable<Product> GetProducts()
        {
            return products;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public HttpResponseMessage PostProducts([FromBody]Product product)
        {
            var prod = products.FirstOrDefault((p) => p.Id == product.Id);
            if (prod == null)
            {
                products.Add(product);
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }


        }

        [HttpDelete]
        public IHttpActionResult DeleteProducts(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                products.Remove(product);
                return Ok(id);
            }
            
        }
    }
}
