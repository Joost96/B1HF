using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFestival.Model
{
    public class PagePlusActivityPlusOrderDinners
    {
        public Order Order { get; set; }
        public Page Page { get; set; }
        public Activity Activity { get; set; }

        public int NumberOfAdults { get; set; }
        public int NumberOfKids { get; set; }
        public DateTime Day { get; set; }
        public DateTime Time { get; set; }

        public Activity SugestionActivityJazz { get; set; }
        public Activity SugestionActivityHistoric { get; set; }
        public Activity SugestionActivityDinner { get; set; }
        public Activity SugestionActivityTalking { get; set; }
    }
}