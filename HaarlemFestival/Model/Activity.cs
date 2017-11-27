using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaarlemFestival.Model
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public EventType Type { get; set; }

        [Required, ForeignKey("Location")]
        public int Location_Id { get; set; }
        public virtual Location Location { get; set; }

        public List<ActivityDescription> ActivityDescriptions { get; set; }

        public List<TimeSlot> Timeslots { get; set; }
        public List<Cuisine> Cuisines { get; set; }
    }
}