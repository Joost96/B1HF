using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFestival.Model
{
    public class OrderHasTickets
    {
        public int OrderId { get; set; }
        public int ActivityId { get; set; }
        public DateTime StartTime { get; set; }

        public int Amount { get; set; }
        public decimal TotalPrice { get; set; }
    }
}