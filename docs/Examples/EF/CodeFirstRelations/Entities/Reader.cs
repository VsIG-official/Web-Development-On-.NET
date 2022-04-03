using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL
{
    public class Reader
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //1-to-many
        public virtual ICollection<Book> Books { get; set; }
        public Reader()
        {
            Books = new List<Book>();
        }
    }
}