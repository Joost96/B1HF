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
        private DBHF db = new DBHF();

        // GET: Dinner
        public ActionResult Index()
        {

            DBHF db = new DBHF();

            PagePlusActivitiesPlusCuisine pagePlusActivitiesPlusCuisine = new PagePlusActivitiesPlusCuisine();

            IPageRepository pageRepo = new PageRepository(db);
            Page page = pageRepo.GetPage("Dinner", Language.Eng);

            IActivityRepository activityRepo = new ActivityRepository(db);
            IEnumerable<Activity> activities = activityRepo.GetActivities(EventType.Dinner, Language.Eng);

            ICuisineRepository cuisineRepo = new CuisineRepository(db);
            IEnumerable<Cuisine> cuisines = cuisineRepo.GetCuisines();


            foreach (Activity a in activities)
            {
                a.Cuisines = cuisineRepo.GetCuisines(a);
            }


            activities.OrderBy(Activity => Activity.Rating);

            pagePlusActivitiesPlusCuisine.Cuisines = cuisines.ToList();
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
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }

            return View(activity);
        }

    }
}
