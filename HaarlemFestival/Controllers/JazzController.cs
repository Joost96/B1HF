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

            IActivityRepository activityRepo = new ActivityRepository(db);
            IEnumerable<Activity> activities = activityRepo.GetActivities(EventType.Jazz);

            activities.OrderBy(Activitie => Activitie.Timeslots);

            PageDescriptions.Page = page;
            PageDescriptions.ActivityDescriptions = activities.ToList();

            return View(PageDescriptions);
        }
    }
}