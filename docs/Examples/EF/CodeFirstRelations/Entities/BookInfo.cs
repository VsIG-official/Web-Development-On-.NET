using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public class BookInfo
    {
        [Key]
        [ForeignKey("Book")]
        public int Id { get; set; }
        //public string Description { get; set; }
        public int Published { get; set; }

        // 1-to-1
        public virtual Book Book { get; set; }        
    }

    public class BookDetail
    {
        [Key]
        [ForeignKey("Bookss")]
        public int Id { get; set; }
        //public string Description { get; set; }
        public int Applied { get; set; }

        // 1-to-1
        public virtual Book Bookss { get; set; }
    }
}