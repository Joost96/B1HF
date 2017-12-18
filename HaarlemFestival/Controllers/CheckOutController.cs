using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HaarlemFestival.Model;
using HaarlemFestival.Repositories;

namespace HaarlemFestival.Controllers
{
    public class CheckOutController : Controller
    {
        private DBHF db;
        private IOrderRepository orderRepository;
        private IPageRepository pageRepository;

        public CheckOutController()
        {
            db = new DBHF();
            orderRepository = new OrderRepository(db);
            pageRepository = new PageRepository(db);
        }
        // GET: CheckOut
        public ActionResult CheckOut1()
        {
            return View();
        }

        public ActionResult CheckOut2()
        {
            return View();
        }

        public ActionResult CheckOut3()
        {
            Order order = (Order)Session["order"];
            return View(order);
        }
        [HttpPost]
        public ActionResult CheckOut3(Order order)
        {
            order.CustomerId = ((Account)(Session["loggedin_account"])).Id;
            order.Date = DateTime.Now;

            orderRepository.CreateOrder(order);
            return Redirect("CheckOut4");
        }

        public ActionResult CheckOut4()
        {
            return View();
        }

        public ActionResult Basket()
        {
            PagePlusOrders pagePlusOrders = new PagePlusOrders
            {
                Page = pageRepository.GetPage("PersonalAganda", Language.Eng),
                Orders = orderRepository.GetOrdersCustomer(2).ToList()
            };
            if(Session["order"] != null)
            {
                pagePlusOrders.Orders.Add((Order)Session["order"]);
            }
            return View(pagePlusOrders);
        }

        public ActionResult Order(int activityId, DateTime timeslot, TicketType tickettype, int aantal, decimal totaalprijs, string commentaar=null)
        {

            Order order;
            Ticket ticket = new Ticket();

            OrderHasTickets ticketOrder = new OrderHasTickets();
            ticketOrder.Ticket_TimeSlot_Activity_Id = activityId;
            ticketOrder.Ticket_TimeSlot_StartTime = timeslot;
            ticketOrder.Ticket_Type = tickettype;
            ticketOrder.Amount = aantal;
            ticketOrder.TotalPrice = totaalprijs;

            if (commentaar != null)
            {
                ticketOrder.Remarks = commentaar;
            }

            if (Session["order"] == null)
            {
                order = new Order();
                order.OrderHasTickets.Add(ticketOrder);
                Session["order"] = order; 
            }
            else
            {
                order = (Order)Session["order"];
                order.OrderHasTickets.Add(ticketOrder);
                Session["order"] = order;
            }

            return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString());
        }
    }
}