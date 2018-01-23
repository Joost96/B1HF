using HaarlemFestival.Model;
using HaarlemFestival.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaarlemFestival.Controllers
{
    
    public class ContactController : Controller
    {
        DBHF db;
        IPageRepository pageRepo;

        public ContactController()
        {
            db = new DBHF();
            pageRepo = new PageRepository(db);
        }
        // GET: Contact
        public ActionResult Index()
        {
            Page page = pageRepo.GetPage("Contact", Language.Eng);
            return View(page);
        }
    }
}