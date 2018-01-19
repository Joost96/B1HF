using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HaarlemFestival.Model;
using HaarlemFestival.Repositories;
using System.Web.Security;

namespace HaarlemFestival.Controllers
{
    public class CheckOutController : Controller
    {
        private DBHF db;
        private IOrderRepository orderRepository;
        private IPageRepository pageRepository;
        private IAccountRepository accountRepository;

        public CheckOutController()
        {
            db = new DBHF();
            orderRepository = new OrderRepository(db);
            pageRepository = new PageRepository(db);
            accountRepository = new AccountRepository(db);
        }
        // GET: CheckOut
        public ActionResult CheckOut1()
        {
            Order order = (Order)Session["order"];
            if (order == null)
                order = new Order();
            order.OrderHasTickets.Add(new OrderHasTickets
            {
                Amount = 1,
                Ticket_TimeSlot_StartTime = new DateTime(2018,7,28,21,0,0),
                Ticket_Type = TicketType.Single,
                Ticket_TimeSlot_Activity_Id = 31,
                TotalPrice = 33
            });
            Session["order"] = order;
            Account account = (Account)(Session["loggedin_account"]);
            if (account is Customer)
            {
                //Order order = (Order)Session["order"];
                order.CustomerId = account.Id;
                order.Customer = (Customer)account;
                Session["order"] = order;
                return RedirectToAction("Checkout3", "Checkout");
            }
            return View();
        }
        [HttpPost]
        public ActionResult CheckOut1(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                Account account = accountRepository.GetAccount(model.Email, model.Password);
                if (account != null)
                {
                    if (account is Customer)
                    {
                        FormsAuthentication.SetAuthCookie(account.Id.ToString(), false);

                        Session["loggedin_account"] = account;

                        Order order = (Order)Session["order"];
                        order.Customer = (Customer)account;
                        order.CustomerId = account.Id;
                        Session["order"] = order;

                        return RedirectToAction("CheckOut3", "CheckOut");
                    } else
                    {
                        ModelState.AddModelError("login-error", "The account is not a customer");
                    }
                }
                else
                {
                    ModelState.AddModelError("login-error", "The username or password is incorrect");
                }
            }
            return View(model);
        }

        public ActionResult CheckOut2()
        {
            Order order = (Order)Session["order"];
            return View(order);
        }
        [HttpPost]
        public ActionResult Checkout2(RegisterCheckoutModel model)
        {
            if (ModelState.IsValid)
            {
                Account checkAccount = accountRepository.GetAccount(model.Email);
                if (checkAccount == null)
                {
                    Account account = new Customer(model.Email, model.FirstName, model.LastName, model.Password, model.Country);
                    accountRepository.Register(account);

                    FormsAuthentication.SetAuthCookie(account.Id.ToString(), false);

                    Session["loggedin_account"] = account;

                    Order order = (Order)Session["order"];
                    order.Customer = (Customer)account;
                    order.CustomerId = account.Id;
                    Session["order"] = order;

                    return RedirectToAction("Checkout3", "CheckOut");
                }
                else
                {
                    ModelState.AddModelError("register-error", "The email is already taken");
                }
            }
            return View(model);
        }

        public ActionResult CheckOut3()
        {
            Order order = (Order)Session["order"];
            return View(order);
        }
        [HttpPost]
        public ActionResult CheckOut3(Order order)
        {           
            order.Date = DateTime.Now;
            Session["order"] = order;
            orderRepository.CreateOrder(order);
            return Redirect("CheckOut4");
        }

        public ActionResult CheckOut4()
        {
            Order order = (Order)Session["order"];
            if(order.PaymentMethod != null)
                Session["order"] = null;
            return View(order);
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

        [HttpPost]
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