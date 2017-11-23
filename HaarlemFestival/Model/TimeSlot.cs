using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HaarlemFestival.Model
{
    public class TimeSlot
    {
        [Key]
        public int ActivityId { get; set; }
        public virtual Activity Activity { get; set; }
        [Key]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [Required]
        public int TotalSeats { get; set; }
        [Required]
        public int FreeSeats { get; set; }

        public string Hall { get; set; }   // somige locaties hebben verschillende hallen binnen die locatie

    }
}