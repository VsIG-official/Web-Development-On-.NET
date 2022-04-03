using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Genre
    {
        public int Id { get; set; }
        public string GenreName { get; set; }

        //many-to-many
        public virtual ICollection<Book> Books { get; set; }
        public Genre()
        {
            Books = new List<Book>();
        }
    }
}
