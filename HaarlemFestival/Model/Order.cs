using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HaarlemFestival.Model
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        [Required]
        public PaymentMethod? PaymentMethod { get; set; }

        public List<OrderHasTickets> OrderHasTickets { get; set; }

        //public Order() => OrderHasTickets = new List<OrderHasTickets>();
    }
}