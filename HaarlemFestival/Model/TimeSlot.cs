using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaarlemFestival.Model
{
    public class TimeSlot
    {
        [Column(Order =0), Key, ForeignKey("Activity")]
        public int Activity_Id { get; set; }
        public virtual Activity Activity { get; set; }
        [Column(Order = 1), Key]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [Required]
        public int TotalSeats { get; set; }
        [Required]
        public int OccupiedSeats { get; set; }

        public string Hall { get; set; }   // somige locaties hebben verschillende hallen binnen die locatie

        public List<Ticket> Tickets { get; set; }

    }
}