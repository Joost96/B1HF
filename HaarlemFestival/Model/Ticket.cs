using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaarlemFestival.Model
{
    public class Ticket
    {
        [Column(Order = 0), Key, ForeignKey("TimeSlot")]
        public int TimeSlot_Activity_Id { get; set; }
        [Column(Order = 1), Key, ForeignKey("TimeSlot")]
        public DateTime TimeSlot_StartTime { get; set; }

        public virtual TimeSlot TimeSlot { get; set; }
        [Column(Order = 2), Key]
        public TicketType Type { get; set; }

        [Required]
        public decimal Price { get; set; }
              

        public List<OrderHasTickets> OrderHasTickets { get; set; }

    }
}