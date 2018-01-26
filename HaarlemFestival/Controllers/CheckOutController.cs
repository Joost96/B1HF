using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HaarlemFestival.Model;
using HaarlemFestival.Repositories;
using System.Web.Security;
using HaarlemFestival.Model.Helpers;

namespace HaarlemFestival.Controllers
{
    public class CheckOutController : Controller
    {
        private DBHF db;
        private IOrderRepository orderRepository;
        private IPageRepository pageRepository;
        private IAccountRepository accountRepository;
        private IActivityRepository activityRepository;
        

        public CheckOutController()
        {
            db = new DBHF();
            orderRepository = new OrderRepository(db);
            pageRepository = new PageRepository(db);
            accountRepository = new AccountRepository(db);
            activityRepository = new ActivityRepository(db);
        }

        public ActionResult Basket()
        {
            Order order = (Order)Session["order"];
            Language language = (Language)Session["Language"];
            PagePlusOrders pagePlusOrders = new PagePlusOrders { Page = pageRepository.GetPage("PersonalAgenda", language) };

            if (Session["order"] != null)
            {
                pagePlusOrders.Orders = orderRepository.GetOrdersCustomer(order.CustomerId).ToList();
                pagePlusOrders.Orders.Add(order);
            }
            return View(pagePlusOrders);
        }

        public ActionResult Delete(int ohdId)
        {
            Order order = (Order)Session["order"];
            foreach (var orderhasticket in order.OrderHasTickets)
            {
                if (orderhasticket.Ticket_TimeSlot_Activity_Id == ohdId)
                {
                    order.OrderHasTickets.Remove(orderhasticket);
                    break;
                }
            }
            Session["order"] = order;
            return RedirectToAction("Basket");
        }

        // GET: CheckOut
        public ActionResult CheckOut1()
        {
            PagePlusOrderPlusLogin ppp = new PagePlusOrderPlusLogin();

            Order order = (Order)Session["order"];
            ppp.Orders.Add(order);
            Language language = (Language)Session["language"];

            ppp.Page = pageRepository.GetPage("CheckOut", language);

            Account account = (Account)(Session["loggedin_account"]);
            if (account is Customer)
            {
                order.CustomerId = account.Id;
                order.Customer = (Customer)account;
                Session["order"] = order;
                return RedirectToAction("Checkout3", "Checkout");
            }

            return View(ppp);
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
                        FormsAuthentication.SetAuthCookie(account.Email, false);

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

                    FormsAuthentication.SetAuthCookie(account.Email, false);

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

        public ActionResult OrderJazz(int id, int aantal)
        {

	        Language language = (Language)Session["language"];
            Activity activity = activityRepository.GetActivity(id, language);

            OrderHasTickets ticketOrder = new OrderHasTickets();
            ticketOrder.Ticket_TimeSlot_Activity_Id = activity.Id;
            ticketOrder.Ticket_TimeSlot_StartTime = activity.Timeslots[0].StartTime;
            ticketOrder.Ticket_Type = activity.Timeslots[0].Tickets[0].Type;
            ticketOrder.Amount = aantal;
            ticketOrder.Ticket = activity.Timeslots[0].Tickets[0];
            ticketOrder.TotalPrice = aantal * activity.Timeslots[0].Tickets[0].Price;

            Order order = (Order)Session["order"];
            if (order == null)
            {
                order = new Order();
                order.OrderHasTickets.Add(ticketOrder);
            }
            else
            {
                OrderHasTickets OHT = order.OrderHasTickets.Where(x => x.Ticket_TimeSlot_Activity_Id == ticketOrder.Ticket_TimeSlot_Activity_Id).SingleOrDefault();
                if (OHT != null)
                {
                    OHT.Amount += ticketOrder.Amount;
                    OHT.TotalPrice = OHT.Ticket.Price * OHT.Amount;
                }
                else {
                    order.OrderHasTickets.Add(ticketOrder);
                }
            }
            Session["order"] = order;


            BasketHelper.getInstance().checkBasket(HttpContext);

            return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString());
        }
    }
}