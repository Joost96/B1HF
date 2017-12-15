using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HaarlemFestival.Model;

namespace HaarlemFestival.Controllers
{
    public class CheckOutController : Controller
    {
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
            return View();
        }

        public ActionResult CheckOut4()
        {
            return View();
        }

        public ActionResult Order(int activityId, int aantal, string commentaar=null)
        {

            Order order;

            OrderHasTickets ticketOrder = new OrderHasTickets();
            ticketOrder.Ticket_TimeSlot_Activity_Id = activityId;
            ticketOrder.Amount = aantal;

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