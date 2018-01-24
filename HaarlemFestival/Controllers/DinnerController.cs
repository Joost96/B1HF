using HaarlemFestival.Repositories;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.UI.HtmlControls;
using HaarlemFestival.Model;

namespace HaarlemFestival.Controllers
{
    public class DinnerController : Controller
    {
        private DBHF db;
        private IPageRepository pageRepository;
        private IActivityRepository activityRepository;
        private ICuisineRepository cuisineRepository;

        public DinnerController()
        {
            db = new DBHF();
            pageRepository = new PageRepository(db);
            activityRepository = new ActivityRepository(db);
            cuisineRepository = new CuisineRepository(db);
        }

        // GET: Dinner
        public ActionResult Index()
        {


            PagePlusActivitiesPlusCuisine pagePlusActivitiesPlusCuisine = new PagePlusActivitiesPlusCuisine();

            
            Page page = pageRepository.GetPage("Dinner", Language.Eng);

            
            IEnumerable<Activity> activities = activityRepository.GetActivities(EventType.Dinner, Language.Eng);

            
            IEnumerable<Cuisine> cuisines = cuisineRepository.GetCuisines();


            foreach (Activity a in activities)
            {
                a.Cuisines = cuisineRepository.GetCuisines(a);
            }


            activities.OrderBy(a => a.Rating);

            pagePlusActivitiesPlusCuisine.Cuisines = cuisines.OrderByDescending(c => c.Activities.Count()).ToList();
            pagePlusActivitiesPlusCuisine.Page = page;
            pagePlusActivitiesPlusCuisine.Activities = activities.ToList();
            return View(pagePlusActivitiesPlusCuisine);
        }

        // GET: Dinner/Details/5
        public ActionResult Restaurant(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PagePlusActivities pagePlusActivity = new PagePlusActivities(); 


            Page page = pageRepository.GetPage("Dinner Restaurant", Language.Eng);

            Activity activity = activityRepository.GetActivity(id, Language.Eng);

            activity.Cuisines = cuisineRepository.GetCuisines(activity);

            pagePlusActivity.Page = page;
            pagePlusActivity.Activity = activity;

            if (activity == null)
            {
                return HttpNotFound();
            }

            return View(pagePlusActivity);
        }
    }
}
