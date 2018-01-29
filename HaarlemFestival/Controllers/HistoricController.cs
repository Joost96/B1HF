using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HaarlemFestival.Model;
using HaarlemFestival.Repositories;
using HaarlemFestival.Model.Helpers;

namespace HaarlemFestival.Controllers
{
    public class HistoricController : Controller
    {
        private DBHF db;
        private IPageRepository pageRepository;
        private static IActivityRepository activityRepository;
        private ITicketRepository ticketRepository;

        public HistoricController()
        {
            db = new DBHF();
            pageRepository = new PageRepository(db);
            activityRepository = new ActivityRepository(db);
            ticketRepository = new TicketRepository(db);
        }

        // GET: Historic
        public ActionResult Index()
        {
            Language language = (Language)Session["language"];
            PpApOpQ pagePlusActivities = new PpApOpQ();

            Page page = pageRepository.GetPage("Historic", (Language)Session["language"]);

            IEnumerable<Activity> activities = activityRepository.GetActivities(EventType.Historic, (Language)Session["language"]);

            pagePlusActivities.Page = page;
            pagePlusActivities.Activities = activities.ToList();

            pagePlusActivities.SugestionActivityJazz = SuggestieActivity(EventType.Jazz, language);
            pagePlusActivities.SugestionActivityDinner = SuggestieActivity(EventType.Dinner, language);
            pagePlusActivities.SugestionActivityHistoric = SuggestieActivity(EventType.Historic, language);
            pagePlusActivities.SugestionActivityTalking = SuggestieActivity(EventType.Talking, language);

            return View(pagePlusActivities);
        }

        [HttpPost]
        public ActionResult Index(PpApOpQ model)
        {
            Order order = (Order)Session["Order"];
            if (order == null)
            {
                order = new Order();
            }

            Activity activity = activityRepository.GetActivity(model.OHT.Ticket_TimeSlot_Activity_Id, Language.Eng);

            model.OHT.Ticket =  ticketRepository.GetTicket(activity, model.OHT.Ticket_TimeSlot_StartTime, model.OHT.Ticket_Type);


            order.OrderHasTickets.Add(model.OHT);
            Session["Order"] = order;

            BasketHelper.getInstance().checkBasket(HttpContext);
            return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString());
        }

        public static Activity SuggestieActivity(EventType type, Language language)
        {
            IEnumerable<Activity> activities = activityRepo.GetActivities(type, language);

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