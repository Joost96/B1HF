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
            Page page = pageRepo.GetPage("Jazz", Language.Eng); 
            IEnumerable<Activity> activities = activityRepo.GetActivities(EventType.Jazz, Language.Eng, dDay);

            activities.OrderBy(Activitie => Activitie.Timeslots);

            PageDescriptions.Page = page;
            PageDescriptions.Activities = activities.ToList();

            return View(PageDescriptions);
        }

        [HttpPost]
        public ActionResult OrderJazz(OrderHasTickets model)
        {
            int id = model.Ticket_TimeSlot_Activity_Id;
            //DBHF db = new DBHF();
            //IActivityRepository activityRepository = new ActivityRepository(db);
            //Activity activity = activityRepository.GetActivity(model.Id, Language.Eng);

            //OrderHasTickets ticketOrder = model;
            //ticketOrder.Ticket_TimeSlot_Activity_Id = activity.Id;
            //ticketOrder.Ticket_TimeSlot_StartTime = activity.Timeslots[0].StartTime;
            //ticketOrder.Ticket_Type = activity.Timeslots[0].Tickets[0].Type;
            //ticketOrder.Amount = 5;
            //ticketOrder.TotalPrice = 5 * activity.Timeslots[0].Tickets[0].Price;

            Order order = (Order)Session["order"];
            if (order == null)
            {
                order = new Order();
                order.OrderHasTickets.Add(model);
                Session["order"] = order;
            }
            else
            {
                order = (Order)Session["order"];
                order.OrderHasTickets.Add(model);
                Session["order"] = order;
            }

            return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString());
        }
    }
}