using System;
using BLL.Entities.Abstract;

namespace BLL.Entities
{
    public class OrderDTO : BaseDTO
    {
        public int UserId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
