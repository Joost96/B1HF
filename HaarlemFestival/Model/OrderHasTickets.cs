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
        public int OrderId { get; set; }
        [Key]
        public int ActivityId { get; set; }
        [Key]
        public DateTime StartTime { get; set; }

        [Required]
        public int Amount { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
    }
}