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

        public ActivityRepository(DBHF db)
        {
            this.db = db;
        }

        public IEnumerable<Activity> GetActivities(EventType type, Language language)
        {
            return db.Activities
                .Include(a => a.Location)
                .Include(a => a.Cuisines)
                .Where(a => a.Type == type)
                .Select(a => new
                {
                    a,
                    //c = .Cuisines,
                    d = a.ActivityDescriptions.Where(ad => ad.Language == language)
                                .OrderBy(ad => ad.Section),
                    ts = a.Timeslots,
                    ti = a.Timeslots.Select(ts => ts.Tickets)

                }).AsEnumerable()
                .Select(x => x.a);
        }

        public IEnumerable<Activity> GetActivities(EventType type, Language language, DateTime dag)
        {
            DateTime dag2 = dag.AddDays(1);
            return db.Activities
                .Include(a => a.Location)
                .Where(a => a.Type == type)

                .Select(a => new
                {
                    a,
                    d = a.ActivityDescriptions.Where(ad => ad.Language == language)
                                .OrderBy(ad => ad.Section),
                    ts = a.Timeslots.Where(ts => ts.StartTime >= dag).Where(ts => ts.EndTime <= dag2),
                    ti = a.Timeslots.Select(ts => ts.Tickets)
                }).AsEnumerable().Where(a => a.ts.Count() > 0)
                .Where(a => a.a.Timeslots[0].StartTime.ToString("dd/MM/yyyy").Equals(dag.ToString("dd/MM/yyyy")))
                .Select(x => x.a);
        }

        public Activity GetActivity(int? activityId, Language language)
        {
            return db.Activities
                .Include(a => a.Location)
                .Include(a => a.Timeslots.Select(ts => ts.Tickets))
                .Include(a => a.ActivityDescriptions)
                .Where(a => a.Id == activityId)
                .SingleOrDefault();
        }

        public void UpdateActivity(Activity activity)
        {
            db.Entry(activity).State = EntityState.Modified;
            foreach (ActivityDescription dp in activity.ActivityDescriptions)
            {
                db.Entry(dp).State = EntityState.Modified;
            }
            db.SaveChanges();
        }

    }

    
}
