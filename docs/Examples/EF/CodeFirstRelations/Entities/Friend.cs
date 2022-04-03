using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public class Friend
    {
        //public int id { get; set; }
        //public int? UserId { get; set; }
        //public int? FriendId { get; set; }
        //[ForeignKey("UserId")]
        //public virtual User User { get; set; }
        //[ForeignKey("FriendId")]
        //public virtual User Friended { get; set; }

        public int id { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }
        [ForeignKey("Friended")]
        public int? FriendId { get; set; }
        
        public virtual User User { get; set; }
        
        public virtual User Friended { get; set; }

    }
}
