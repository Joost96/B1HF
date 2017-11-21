using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFestival.Model
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EventType Type { get; set; }

        public Location Location { get; set; }
        public List<ActivityDescription> ActivityDescriptions { get; set; }
    }
}