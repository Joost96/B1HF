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
        public TimeSlot TimeSlot { get; set; }
        [Key]
        public TicketType Type { get; set; }


        [Required]
        public decimal Price { get; set; }
              

        public List<OrderHasTickets> OrderHasTickets { get; set; }

    }
}