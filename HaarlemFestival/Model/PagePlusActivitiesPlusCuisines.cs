using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HaarlemFestival.Model;

namespace HaarlemFestival.Model
{
    public class PagePlusActivitiesPlusCuisine
    { 
        public Page Page { get;  set; }
        public List<Cuisine> Cuisines { get; set; }
        public List<Activity> Activities { get; set; }

        public Activity SugestionActivityJazz { get; set; }
        public Activity SugestionActivityHistoric { get; set; }
        public Activity SugestionActivityDinner { get; set; }
        public Activity SugestionActivityTalking { get; set; }

    }
}