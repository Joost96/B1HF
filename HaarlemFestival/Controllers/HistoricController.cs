using System;
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
        private DBHF db;
        private IPageRepository pageRepository;
        private IActivityRepository activityRepository;

        public HistoricController()
        {
            db = new DBHF();
            pageRepository = new PageRepository(db);
            activityRepository = new ActivityRepository(db);
        }

        // GET: Historic
        public ActionResult Index()
        {
            PagePlusActivities pagePlusActivities = new PagePlusActivities();
            
            Page page = pageRepository.GetPage("Historic", Language.Eng);

            IEnumerable<Activity> activities = activityRepository.GetActivities(EventType.Historic, Language.Eng);

            pagePlusActivities.Page = page;
            pagePlusActivities.Activities = activities.ToList();

            return View(pagePlusActivities);
        }
    }
}