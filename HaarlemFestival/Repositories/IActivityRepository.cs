using HaarlemFestival.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFestival.Repositories
{
    interface IActivityRepository
    {
        IEnumerable<Activity> GetActivities(EventType type);

        IEnumerable<Activity> GetActivities(EventType type, DateTime dag);

    }
}