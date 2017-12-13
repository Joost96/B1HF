﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HaarlemFestival.Model;
using HaarlemFestival.Repositories;

namespace HaarlemFestival.Controllers
{
    public class HistoricController : Controller
    {
        

        // GET: Historic
        public ActionResult Historic()
        {
            PagePlusDescriptions pagePlusDescriptions = new PagePlusDescriptions();
            DBHF db = new DBHF();
            IPageRepository pageRepository = new PageRepository(db);
            Page page = pageRepository.GetPage("Historic", Language.Eng);

            IActivityRepository activityRepository = new ActivityRepository(db);
            IEnumerable<Activity> activities = activityRepository.GetActivities(EventType.Historic, Language.Eng);

            pagePlusDescriptions.Page = page;
            pagePlusDescriptions.ActivityDescriptions = activities.ToList();

            return View(pagePlusDescriptions);
        }
    }
}