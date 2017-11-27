using HaarlemFestival.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaarlemFestival.Controllers
{
    public class ContentManagementController : Controller
    {

        private DBHF db;
        // GET: ContentManager
        public ActionResult Index()
        {
            return View();
        }
    }
}