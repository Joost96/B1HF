using HaarlemFestival.Model;
using HaarlemFestival.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaarlemFestival.Controllers
{
    [Authorize(Roles = "contentManager")]
    public class ContentManagementController : Controller
    {

        private DBHF db;
        private IPageRepository pageRepository;

        public ContentManagementController()
        {
            db = new DBHF();
            pageRepository = new PageRepository(db);
        }

        // GET: ContentManager
        public ActionResult Index()
        {
            Page homePage = pageRepository.GetPage("Home" , Language.Eng);
            return View(homePage);
        }
    }
}