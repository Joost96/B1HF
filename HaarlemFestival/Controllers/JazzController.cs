using HaarlemFestival.Model;
using HaarlemFestival.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaarlemFestival.Controllers
{
    public class JazzController : Controller
    {
        // GET: Jazz
        public ActionResult Index()
        {
            PagePlusDescriptions PageDescriptions = new PagePlusDescriptions();

            DBHF db = new DBHF();
            IPageRepository pageRepo = new PageRepository(db);
            Page page = pageRepo.GetPage("Jazz", Language.Eng);

            DateTime dag1 = new DateTime(2018,07,26,18,00,00,000);

            IActivityRepository activityRepo = new ActivityRepository(db);
            IEnumerable<Activity> activities = activityRepo.GetActivities(EventType.Jazz, dag1);

            activities.OrderBy(Activitie => Activitie.Timeslots);

            PageDescriptions.Page = page;
            PageDescriptions.ActivityDescriptions = activities.ToList();

            //foreach (var item in PageDescriptions.ActivityDescriptions)
            //{
            //    if (item.Timeslots[0].StartTime != dag1)
            //    {
            //        PageDescriptions.ActivityDescriptions.Remove(item);
            //    }
            //}

            return View(PageDescriptions);
        }

        
    }
}