﻿using HaarlemFestival.Repositories;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.HtmlControls;
using HaarlemFestival.Model;
using System;
using HaarlemFestival.Model.Helpers;

namespace HaarlemFestival.Controllers
{
    public class DinnerController : Controller
    {
        private DBHF db;
        private IPageRepository pageRepository;
        private IActivityRepository activityRepository;
        private ICuisineRepository cuisineRepository;
        private ITicketRepository ticketRepository;
         
        public DinnerController()
        {
            db = new DBHF();
            pageRepository = new PageRepository(db);
            activityRepository = new ActivityRepository(db);
            cuisineRepository = new CuisineRepository(db);
            ticketRepository = new TicketRepository(db); 
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

            //PagePlusActivities pagePlusActivity = new PagePlusActivities(); 
            PagePlusActivityPlusOrderDinners pagePlusActivityPlusOrder = new PagePlusActivityPlusOrderDinners();


            Page page = pageRepository.GetPage("Dinner Restaurant", Language.Eng);

            Activity activity = activityRepository.GetActivity(id, Language.Eng);

            activity.Cuisines = cuisineRepository.GetCuisines(activity);

            pagePlusActivityPlusOrder.Page = page;
            pagePlusActivityPlusOrder.Activity = activity;

            if (activity == null)
            {
                return HttpNotFound();
            }

            return View(pagePlusActivityPlusOrder);
        }


        [HttpPost]
        public ActionResult Order(PagePlusActivityPlusOrderDinners model)
        {
            Order order = (Order)Session["order"];

            if (order == null)
            {
                order = new Order();             
            }

            DateTime startTime = model.Day.Date + model.Time.TimeOfDay;
            Activity activity = activityRepository.GetActivity(model.Activity.Id, Language.Eng);          
            
            OrderHasTickets ticketOrder = new OrderHasTickets();

            ticketOrder.Ticket_TimeSlot_Activity_Id = model.Activity.Id;
            ticketOrder.Remarks = model.Order.OrderHasTickets[0].Remarks;
            ticketOrder.Ticket_TimeSlot_StartTime = model.Day.Date + model.Time.TimeOfDay;
            ticketOrder.Ticket_Type = TicketType.Single;
            ticketOrder.Amount = model.NumberOfAdults;

            ticketOrder.Ticket = ticketRepository.GetTicket(activity, startTime, ticketOrder.Ticket_Type);

            ticketOrder.TotalPrice = model.NumberOfAdults * ticketOrder.Ticket.Price;

            order.OrderHasTickets.Add(ticketOrder);


            if (model.NumberOfKids > 0)
            {
                OrderHasTickets to = new OrderHasTickets();

                to.Ticket_TimeSlot_Activity_Id = model.Activity.Id;
                to.Remarks = model.Order.OrderHasTickets[0].Remarks;
                to.Ticket_TimeSlot_StartTime = model.Day.Date + model.Time.TimeOfDay;
                to.Ticket_Type = TicketType.Child;
                to.Amount = model.NumberOfKids;

                to.Ticket = ticketRepository.GetTicket(activity, startTime, to.Ticket_Type);
                to.TotalPrice = model.NumberOfKids * ticketOrder.Ticket.Price;
                order.OrderHasTickets.Add(to);
            }

            Session["order"] = order;

            BasketHelper.getInstance().checkBasket(HttpContext);
            return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString());
        }
    }
}
