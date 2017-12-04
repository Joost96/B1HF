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
        // GET: Contact
        public ActionResult Index()
        {
            DBHF db = new DBHF();
            IPageRepository pageRepo = new PageRepository(db);
            Page page = pageRepo.GetPage("Contact", Language.Eng);

            return View(page);
        }
    }
}