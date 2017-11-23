using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HaarlemFestival.Model;

namespace HaarlemFestival.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private DBHF db;
        //private List<Activity> Activities { get; set; }

        public ActivityRepository(DBHF db)
        {
            this.db = db;
             
        }

        public IEnumerable<Activity> GetActivities(EventType type)
        {


            return db.Activity.Include(a => a.Location)
                .Include(a => a.ActivityDescriptions)
                .Include(a => a.Timeslots.Select(t => t.Tickets))
                .Where(a => a.Type == type);
        }
    }
}