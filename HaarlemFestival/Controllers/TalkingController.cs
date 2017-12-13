using HaarlemFestival.Model;
using HaarlemFestival.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaarlemFestival.Controllers
{
    public class TalkingController : Controller
    {
        // GET: Talking
        public ActionResult Index()
        {
            PagePlusActivities PageDescriptions = new PagePlusActivities();

            DBHF db = new DBHF();
            IPageRepository pageRepo = new PageRepository(db);
            Page page = pageRepo.GetPage("Talking", Language.Eng);

            IActivityRepository activityRepo = new ActivityRepository(db);
            IEnumerable<Activity> activities = activityRepo.GetActivities(EventType.Talking, Language.Eng);

            activities.OrderBy(Activitie => Activitie.Timeslots);

            PageDescriptions.Page = page;
            PageDescriptions.Activities = activities.ToList();

            return View(PageDescriptions);
        }

        // $(".TalkingButtonSpreker").click(function(){})
        // $(".TalkingButtonSpreker2").click(function(){})
        // $(".TalkingButtonBook").click(function(){})





    }
}