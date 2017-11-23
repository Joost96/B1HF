using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HaarlemFestival.Model
{
    public class OrderHasTickets
    {
        [Key]
        public Order Order { get; set; }

        [Key]
        public Ticket Ticket { get; set; }

        [Required]
        public int Amount { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
    }
}