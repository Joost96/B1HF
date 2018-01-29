using HaarlemFestival.Model;
using HaarlemFestival.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HaarlemFestival.Controllers
{
    [Authorize(Roles = "contentManager")]
    public class SalesController : Controller
    {
        private DBHF db;
        private IActivityRepository activityRepository;
        private IOrderRepository orderRepository;

        public SalesController()
        {
            db = new DBHF();
            activityRepository = new ActivityRepository(db);
            orderRepository = new OrderRepository(db);
        }
        // GET: Sales
        public ActionResult Index()
        {
            SalesInfo info = new SalesInfo();
            foreach (EventType type in Enum.GetValues(typeof(EventType))) {
                if (type != EventType.JazzPass)
                {
                    AddToInfo(type, info);
                }
            }
            info.GetTop10();
            return View(info);
        }

        // GET : Event
        public ActionResult Event(int? id)
        {
            if (id != null)
            {
                if (Enum.IsDefined(typeof(EventType), id))
                {
                    EventType type = (EventType)id;
                    SalesInfo info = new SalesInfo();
                    AddToInfo(type, info);
                    info.GetTop10();
                    info.PageName = type.ToString();
                    return View(info);
                }               
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        public void AddToInfo(EventType type , SalesInfo info)
        {
            List<TimeSlot> timeslots = activityRepository.GetTimeslots(type).ToList();
            //amount sold
            int total = timeslots.Sum(ts => ts.TotalSeats);
            int sold = timeslots.Sum(ts => ts.OccupiedSeats);
            info.AddAmountSold(type, sold, total);

            //country stats
            List<OrderHasTickets> ohts = orderRepository.getOrdersFromEvent(type).ToList();
            var countries = ohts
                .GroupBy(oht => oht.Order.Customer.Country)
                .Select(x => new { Country = x.Key, count = x.Count(), amount = x.Average(y => y.Amount) })
                .OrderByDescending(x => x.count);
            foreach (var country in countries)
            {
                info.AddCountry(country.Country, (int)Math.Floor(country.count * country.amount));
            }

            //activity sales
            var Activities = timeslots
                .GroupBy(ts => ts.Activity)
                .Select(x => new { activity = x.Key.Name, count = x.Count(), amount = x.Average(y => y.OccupiedSeats) })
                .OrderByDescending(x => x.count);
            foreach (var activity in Activities)
            {
                info.AddActivity(activity.activity, (int)Math.Floor(activity.count * activity.amount));
            }

            //DailySales
            for(int i =0;i<14;i++)
            {
                DateTime date = DateTime.Now.AddDays(-i);
                DateTime date2 = date.AddDays(1);
                int amount = ohts.Where(oht => oht.Order.Date <= date2 && oht.Order.Date >= date).Sum(x => x.Amount);

                info.AddDailySale(date, amount);
            }
            //var DailySales = ohts
            //    .GroupBy(oht => oht.Order.Date.Date)
            //    .Select(x => new { date = x.Key, count = x.Count(), amount = x.Average(y => y.Amount) })
            //    .OrderByDescending(x => x.count);
            //foreach (var day in DailySales)
            //{
            //    info.AddDailySale(day.date, (int)Math.Floor(day.count * day.amount));
            //}

            //timeslots
            foreach (TimeSlot ts in timeslots)
            {
                info.AddTimeslot(ts, ts.OccupiedSeats);
            }
        }
    }
}