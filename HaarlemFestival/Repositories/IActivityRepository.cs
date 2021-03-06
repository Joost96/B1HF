﻿using HaarlemFestival.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFestival.Repositories
{
    interface IActivityRepository
    {
        IEnumerable<Activity> GetActivities(EventType type, Language language);

        IEnumerable<Activity> GetActivities(EventType type, Language language, DateTime dag);

        IEnumerable<TimeSlot> GetTimeslots(EventType type);

        Activity GetActivity(int? activityId, Language language);

        void UpdateActivity(Activity activity);

    }
}