using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaarlemFestival.Model
{
    public class OrderHasTickets
    {
        [Column(Order=0),Key, ForeignKey("Order")]
        public int Order_Id { get; set; }
        public virtual Order Order { get; set; }

        [Column(Order=1),Key, ForeignKey("Ticket")]
        public int Ticket_TimeSlot_Activity_Id { get; set; }
        [Column(Order = 2), Key, ForeignKey("Ticket")]
        public DateTime Ticket_TimeSlot_StartTime { get; set; }
        [Column(Order = 3), Key, ForeignKey("Ticket")]
        public TicketType Ticket_Type { get; set; }

        public virtual Ticket Ticket { get; set; }

        [Required]
        public int Amount { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
    }
}