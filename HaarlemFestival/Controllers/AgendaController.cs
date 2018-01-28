using HaarlemFestival.Model;
using HaarlemFestival.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace HaarlemFestival.Controllers
{
    public class AgendaController : Controller
    {
        private DBHF db;
        private IPageRepository pageRepository;
        private IOrderRepository orderRepository;

        public AgendaController()
        {
            db = new DBHF();
            orderRepository = new OrderRepository(db);
            pageRepository = new PageRepository(db);
        }

        // GET: Agenda
        public ActionResult Index()
        {
            PagePlusOrdersPlusOrderLocation pagePlusOrdersPlusOrderLocation = new PagePlusOrdersPlusOrderLocation();
            Account account = (Account)Session["loggedin_user"];

            pagePlusOrdersPlusOrderLocation.Page = pageRepository.GetPage("PersonalAgenda", Language.Eng);

            if (account != null)
            {
                pagePlusOrdersPlusOrderLocation.Orders = orderRepository.GetOrdersCustomer(account.Id).ToList();
            }

            pagePlusOrdersPlusOrderLocation.orderLoctions = CalculatePosition(pagePlusOrdersPlusOrderLocation.Orders);
            
            return View(pagePlusOrdersPlusOrderLocation);
        }

        public List<OrderLocation> CalculatePosition(List<Order> orders)
        {

            List<OrderLocation> OLL = new List<OrderLocation>();

            foreach (Order order in orders)
            {
                foreach (OrderHasTickets OHT in order.OrderHasTickets)
                {
                    OrderLocation OL = new OrderLocation();

                    int aantaldagen = 0;

                    if (OHT.Ticket.TimeSlot.StartTime.DayOfWeek == DayOfWeek.Thursday)
                    {
                        aantaldagen = 0;
                    }
                    else if (OHT.Ticket.TimeSlot.StartTime.DayOfWeek == DayOfWeek.Friday)
                    {
                        aantaldagen = 1;
                    }
                    else if (OHT.Ticket.TimeSlot.StartTime.DayOfWeek == DayOfWeek.Saturday)
                    {
                        aantaldagen = 2;
                    }
                    else if (OHT.Ticket.TimeSlot.StartTime.DayOfWeek == DayOfWeek.Sunday)
                    {
                        aantaldagen = 3;
                    }

                    OL.bottom = (64.2 - 20 * aantaldagen);
                    OL.left = (2.2 + 7.35 * (OHT.Ticket.TimeSlot.StartTime.Hour - 10) + OHT.Ticket.TimeSlot.StartTime.Minute * 0.12375);
                    OL.width = (7.35 *(OHT.Ticket.TimeSlot.EndTime.Hour - OHT.Ticket.TimeSlot.StartTime.Hour) + (0.12375 *(OHT.Ticket.TimeSlot.EndTime.Minute - OHT.Ticket.TimeSlot.StartTime.Minute)));
                    OL.id = OHT.Ticket_TimeSlot_Activity_Id;

                    OLL.Add(OL);
                }
            }

            return OLL;
        }
    }
}