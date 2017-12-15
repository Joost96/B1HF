using HaarlemFestival.Model;
using HaarlemFestival.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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
            PagePlusOrders pagePlusOrders = new PagePlusOrders
            {
                Page = pageRepository.GetPage("PersonalAganda", Language.Eng),
                Orders = orderRepository.GetOrdersCustomer(2).ToList()
            };
            return View(pagePlusOrders);
        }
    }
}