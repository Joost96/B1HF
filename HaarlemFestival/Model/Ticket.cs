using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFestival.Model
{
    public class Ticket
    {
        public int ActivityId { get; set; }
        public DateTime StartTime { get; set; }
        public decimal Price { get; set; }
        public TicketType Type { get; set; }

        public List<OrderHasTickets> OrderHasTickets { get; set; }

    }
}