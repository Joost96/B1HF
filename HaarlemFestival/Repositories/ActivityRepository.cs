﻿using System;
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

        public IEnumerable<Activity> GetActivities(EventType type, Language language)
        {
            return db.Activities
                .Include(a => a.Location)
                .Where(a => a.Type == type)
                .Select(a => new {
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
            return db.Activities
                .Include(a => a.Location)
                .Where(a => a.Type == type)
                
                .Select(a => new {
                    a,
                    d = a.ActivityDescriptions.Where(ad => ad.Language == language)
                                .OrderBy(ad => ad.Section),
                    ts = a.Timeslots,
                    ti = a.Timeslots.Select(ts => ts.Tickets)
                }).AsEnumerable()
                .Where(a => a.a.Timeslots[0].StartTime.ToString("dd/MM/yyyy").Equals(dag.ToString("dd/MM/yyyy")))
                .Select(x => x.a);

        }
    }
}