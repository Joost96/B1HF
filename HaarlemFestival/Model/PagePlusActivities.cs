﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFestival.Model
{
    public class PagePlusActivities
    {
        public Page Page { get; set; }
        public List<Activity> Activities { get; set; }
        public Activity Activity { get; set; }
    }
}