using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HaarlemFestival.Model;

namespace HaarlemFestival.Controllers
{
    public class DinnerController : Controller
    {
        private DBHF db = new DBHF();

        // GET: Dinner
        public ActionResult Index()
        {
            var activities = db.Activities.Include(a => a.Location);
            return View(activities.ToList());
        }

        // GET: Dinner/Details/5
        public ActionResult Details(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Activity activity = db.Activities.Find(id);
            //if (activity == null)
            //{
            //    return HttpNotFound();
            //}
            return View(/*activity*/);
        }
    }
}
