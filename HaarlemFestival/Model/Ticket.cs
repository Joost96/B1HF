using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HaarlemFestival.Model
{
    public class Ticket
    {
        [Key]
        public int ActivityId { get; set; }
        [Key]
        public DateTime StartTime { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public TicketType Type { get; set; }

        public List<OrderHasTickets> OrderHasTickets { get; set; }

    }
}