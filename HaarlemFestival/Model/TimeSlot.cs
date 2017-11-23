using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HaarlemFestival.Model
{
    public class TimeSlot
    {
        public int ActivityId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int TotalSeats { get; set; }
        public int FreeSeats { get; set; }
        public string Hall { get; set; }   // somige locaties hebben verschillende hallen binnen die locatie

    }
}