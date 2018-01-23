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
        private DBHF db = new DBHF();
        IPageRepository pageRepository;

        public HomeController()
        {
            db = new DBHF();
            pageRepository = new PageRepository(db);
        }
        public ActionResult Index()
        {
            Page page = pageRepository.GetPage("Home" , Language.Eng);
            
            return View(page);
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