using HaarlemFestival.Model;
using HaarlemFestival.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaarlemFestival.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            DBHF db = new DBHF();
            IActivityRepository repository = new ActivityRepository(db);
            IPageDescriptionRepository pageRepo = new PageDescriptionRepository(db);
            PageDescription img = pageRepo.GetImg("1", "Jazz");
            
            //IPageDescriptionRepository pageRepo = new PageDescription; 
            //List<Activity> activity = repository.GetActivities(EventType.Talking).ToList();
            //List<Activity> activities = new List<Activity>(activity);
            return View(img.ToString());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}