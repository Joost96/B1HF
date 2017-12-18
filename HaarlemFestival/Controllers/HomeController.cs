using HaarlemFestival.Model;
using HaarlemFestival.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaarlemFestival.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            DBHF db = new DBHF();
            IPageRepository pageRepo = new PageRepository(db);
            Page page = pageRepo.GetPage("Home" , Language.Eng);
            
            return View(page);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ChangeLanguage(int language)
        {
            if (language == 0)
            {
                Session["language"] = Language.Eng;
            }
            else
            {
                Session["language"] = Language.Ned;
            }

            return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString());
        }
    }
}