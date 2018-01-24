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
        private IActivityRepository activityRepo;
        

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
            IEnumerable<Activity> activities = activityRepo.GetActivities(EventType.Jazz, language, dDay);

            activities.OrderBy(Activitie => Activitie.Timeslots);

            PageDescriptions.Page = page;
            PageDescriptions.Activities = activities.ToList();

            return View(PageDescriptions);
        }

        public ActionResult OrderJazz(int id, int aantal)
        {
            Language language = (Language)Session["language"];

            int id1 = id;
            int aantal1 = aantal;

            DBHF db = new DBHF();
            IActivityRepository activityRepository = new ActivityRepository(db);
            Activity activity = activityRepository.GetActivity(id, language);

            OrderHasTickets ticketOrder = new OrderHasTickets();
            ticketOrder.Ticket_TimeSlot_Activity_Id = activity.Id;
            ticketOrder.Ticket_TimeSlot_StartTime = activity.Timeslots[0].StartTime;
            ticketOrder.Ticket_Type = activity.Timeslots[0].Tickets[0].Type;
            ticketOrder.Amount = aantal;
            ticketOrder.TotalPrice = aantal * activity.Timeslots[0].Tickets[0].Price;

            Order order = (Order)Session["order"];
            if (order == null)
            {
                order = new Order();
                order.OrderHasTickets.Add(ticketOrder);
                Session["order"] = order;
            }
            else
            {
                order.OrderHasTickets.Add(ticketOrder);
                Session["order"] = order;
            }

            return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString());
        }
    }
}