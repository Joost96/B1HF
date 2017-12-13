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
        public ActionResult Index(int? id)
        {
            DateTime dDay = new DateTime(2018, 07, 26);

            if (id != null)
            {
                switch (id)
                {
                    case 1:
                        dDay = new DateTime(2018, 07, 26);
                        break;
                    case 2:
                        dDay = new DateTime(2018, 07, 27);
                        break;
                    case 3:
                        dDay = new DateTime(2018, 07, 28);
                        break;
                    case 4:
                        dDay = new DateTime(2018, 07, 29);
                        break;
                }
            }

            PagePlusActivities PageDescriptions = new PagePlusActivities();

            DBHF db = new DBHF();
            IPageRepository pageRepo = new PageRepository(db);
            Page page = pageRepo.GetPage("Jazz", Language.Eng); 

            IActivityRepository activityRepo = new ActivityRepository(db);
            IEnumerable<Activity> activities = activityRepo.GetActivities(EventType.Jazz, Language.Eng, dDay);

            activities.OrderBy(Activitie => Activitie.Timeslots);

            PageDescriptions.Page = page;
            PageDescriptions.Activities = activities.ToList();

            return View(PageDescriptions);
        }
    }
}