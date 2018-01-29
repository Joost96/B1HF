using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HaarlemFestival.Model;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;

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

        public IEnumerable<TimeSlot> GetTimeslots(EventType type)
        {
            return db.TimeSlots.Include(ts => ts.Activity)
                .Where(ts => ts.Activity.Type == type);
        }

        public void UpdateActivity(Activity activity)
        {
            for(int i=0;i<activity.Timeslots.Count;i++)
            {
                if(activity.Timeslots[i].StartTime != activity.Timeslots[i].Tickets[0].TimeSlot_StartTime)
                {
                    TimeSlot newSlot = new TimeSlot();
                    newSlot.Activity_Id = activity.Timeslots[i].Activity_Id;
                    newSlot.StartTime = activity.Timeslots[i].StartTime;
                    newSlot.EndTime = activity.Timeslots[i].EndTime;
                    newSlot.Tickets = activity.Timeslots[i].Tickets;
                    newSlot.TotalSeats = activity.Timeslots[i].TotalSeats;
                    newSlot.OccupiedSeats = activity.Timeslots[i].OccupiedSeats;
                    newSlot.Hall = activity.Timeslots[i].Hall;
                    activity.Timeslots[i].StartTime = activity.Timeslots[i].Tickets[0].TimeSlot_StartTime;

                    int actID = activity.Timeslots[i].Activity_Id;
                    DateTime startTime = activity.Timeslots[i].StartTime;
                    db.TimeSlots.Remove(db.TimeSlots.Where(
                        time => time.Activity_Id == actID && time.StartTime == startTime).SingleOrDefault()
                        );
                    db.TimeSlots.Add(newSlot);
                    activity.Timeslots[i] = newSlot;
                    for (int j=0;j<activity.Timeslots[i].Tickets.Count;j++)
                    {
                        Ticket newTicket = new Ticket();

                        newTicket.TimeSlot_Activity_Id = newSlot.Activity_Id;
                        newTicket.TimeSlot_StartTime = newSlot.StartTime;
                        newTicket.Price = activity.Timeslots[i].Tickets[j].Price;
                        newTicket.Type = activity.Timeslots[i].Tickets[j].Type;
                        TicketType type = activity.Timeslots[i].Tickets[j].Type;
                        db.Tickets.Remove(db.Tickets.Where(
                            ti => ti.TimeSlot_Activity_Id == actID && ti.TimeSlot_StartTime == startTime && ti.Type == type).SingleOrDefault());
                        activity.Timeslots[i].Tickets[j] = newTicket;
                        db.Tickets.Add(newTicket);
                    }
                }
            }
            db.Entry(activity).State = EntityState.Modified;
            foreach (ActivityDescription dp in activity.ActivityDescriptions)
            {
                db.Entry(dp).State = EntityState.Modified;
            }
            foreach (TimeSlot ts in activity.Timeslots)
            {
                if(db.Entry(ts).State != EntityState.Added)
                    db.Entry(ts).State = EntityState.Modified;
                foreach (Ticket ti in ts.Tickets)
                {
                    if (db.Entry(ti).State != EntityState.Added)
                        db.Entry(ti).State = EntityState.Modified;
                }
            }
            db.SaveChanges();
        }

    }

    
}
