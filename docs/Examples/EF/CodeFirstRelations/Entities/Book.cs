using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class Book
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }

        //1-to-1
        public virtual BookInfo Info { get; set; }

        //1-to-1
        public virtual BookDetail Detail { get; set; }

        //many-to-one
        public int? ReaderId { get; set; }
        public virtual Reader Reader { get; set; }

        //many-to-many
        public virtual ICollection<Genre> Genres { get; set; }
        public Book()
        {
            Genres = new List<Genre>();
        }

    }
}