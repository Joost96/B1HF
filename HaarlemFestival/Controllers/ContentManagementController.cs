using HaarlemFestival.Model;
using HaarlemFestival.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        private IActivityRepository activityRepository;

        public ContentManagementController()
        {
            db = new DBHF();
            pageRepository = new PageRepository(db);
            activityRepository = new ActivityRepository(db);
        }

        // GET: HomePage
        public ActionResult Index()
        {
            Page homePage = pageRepository.GetPage("Home" , Language.Eng);
            return View(homePage);
        }
        // POST: HomePage
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Name,Title,PageDescriptions")] Page page)
        {
            if (ModelState.IsValid)
            {
                UpdatePage(page,"Home");
                return RedirectToAction("index");
            }
            return View(page);
        }
        // GET: Contact
        public ActionResult Contact()
        {
            Page homePage = pageRepository.GetPage("Contact", Language.Eng);
            return View(homePage);
        }
        // POST: Contact
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "Name,Titel,PageDescriptions")] Page page)
        {
            if (ModelState.IsValid)
            {
                UpdatePage(page, "Contact");
                return RedirectToAction("Contact");
            }
            return View(page);
        }

        // GET: Jazz
        public ActionResult Jazz()
        {
            Page page = pageRepository.GetPage("Jazz", Language.Eng);
            List<Activity> activities = activityRepository.GetActivities(EventType.Jazz, Language.Eng).ToList();
            PagePlusActivities pagePlusActivities = new PagePlusActivities
            {
                Page = page,
                Activities = activities
            };
            return View(pagePlusActivities);
        }
        // POST: Jazz
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Jazz([Bind(Include = "Activities,Page")] PagePlusActivities pagePlusActivities)
        {
            if (ModelState.IsValid)
            {
                //UpdatePagePlusActivities(pagePlusActivities, "Jazz");
                return RedirectToAction("Jazz");
            }
            return View(pagePlusActivities);
        }

        // GET: Talking
        public ActionResult Talking()
        {
            Page page = pageRepository.GetPage("Talking", Language.Eng);
            List<Activity> activities = activityRepository.GetActivities(EventType.Talking,Language.Eng).ToList();
            PagePlusActivities pagePlusActivities = new PagePlusActivities
            {
                Page = page,
                Activities = activities
            };
            return View(pagePlusActivities);
        }
        // POST: Talking
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Talking([Bind(Include = "Activities,Page")] PagePlusActivities pagePlusActivities)
        {
            if (ModelState.IsValid)
            {
                //UpdatePagePlusActivities(pagePlusActivities, "Talking");
                return RedirectToAction("Talking");
            }
            return View(pagePlusActivities);
        }

        public void UpdatePagePlusActivities(PagePlusActivities pagePlusActivities, string imgFolder)
        {
            foreach(Activity act in pagePlusActivities.Activities)
            {
                foreach (Description desc in act.ActivityDescriptions)
                {
                    if (desc.ImageUrl != null && desc.ImageUrl.Contains("image/"))
                    {
                        desc.ImageUrl = Saveimage(desc.ImageUrl, imgFolder);
                    }
                }
                activityRepository.UpdateActivity(act);
            }
            UpdatePage(pagePlusActivities.Page, imgFolder);
        }

        public void UpdatePage(Page page, string imgFolder)
        {
            foreach (Description desc in page.PageDescriptions)
            {
                if (desc.ImageUrl != null && desc.ImageUrl.Contains("image/"))
                {
                    desc.ImageUrl = Saveimage(desc.ImageUrl,imgFolder);
                }
            }
            pageRepository.UpdatePage(page);
        }
        public string Saveimage(string img, string imgFolder)
        {

            Bitmap image = new Bitmap(LoadImage(img.Substring(23)));
            string fileName = image.GetHashCode().ToString() + DateTime.Now.Ticks;
            string filePath = "/img/" + imgFolder + "/" + fileName + ".jpeg";
            image.Save(Server.MapPath("~" + filePath));
            return filePath;
        }
        public Image LoadImage(string base64string)
        {
            byte[] imgBytes = Convert.FromBase64String(base64string);
            Image image;
            using(MemoryStream ms = new MemoryStream(imgBytes))
            {
                image = Bitmap.FromStream(ms);
            }
            return image;
        }
    }
}