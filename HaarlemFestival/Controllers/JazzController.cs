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
        private DBHF db;
        private IPageRepository pageRepo;
        private static IActivityRepository activityRepo;
        

        public JazzController()
        {
            db = new DBHF();
            activityRepo = new ActivityRepository(db);
            pageRepo = new PageRepository(db);
        }
        // GET: Jazz
        public ActionResult Index(int? id)
        {
            Language language = (Language)Session["language"];
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
            Page page = pageRepo.GetPage("Jazz", language); 
            List<Activity> activities = activityRepo.GetActivities(EventType.Jazz, language, dDay).ToList();    

            PageDescriptions.Page = page;
            PageDescriptions.Activities = activities.ToList();

            PageDescriptions.SugestionActivityJazz = SuggestieActivity(EventType.Jazz, language);
            PageDescriptions.SugestionActivityDinner = SuggestieActivity(EventType.Dinner, language);
            PageDescriptions.SugestionActivityHistoric = SuggestieActivity(EventType.Historic, language);
            PageDescriptions.SugestionActivityTalking = SuggestieActivity(EventType.Talking, language);

            return View(PageDescriptions);
        }

        public static Activity SuggestieActivity(EventType type, Language language)
        {
            IEnumerable<Activity> activities = activityRepo.GetActivities(type,language);

            int tts = 100;
            Activity activity = new Activity();

            foreach (var act in activities)
            {
                foreach (var slot in act.Timeslots)
                {
                    if (slot.OccupiedSeats < tts)
                    {
                        activity = act;
                        tts = slot.TotalSeats;
                    }
                }
            }
            
            return activity;
        }
    }
}