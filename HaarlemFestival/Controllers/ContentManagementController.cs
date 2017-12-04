﻿using HaarlemFestival.Model;
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
        // POST: Chat/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Name,Titel,PageDescriptions")] Page page)
        {
            if (ModelState.IsValid)
            {
                UpdatePage(page,"Home");
                return RedirectToAction("index");
            }
            return View(page);
        }
        public void UpdatePage(Page page, string imgFolder)
        {
            foreach (Description desc in page.PageDescriptions)
            {
                if (desc.ImageUrl != null && desc.ImageUrl.Contains("image/"))
                {

                    Bitmap image = new Bitmap(LoadImage(desc.ImageUrl.Substring(23)));
                    string fileName = image.GetHashCode().ToString() + DateTime.Now.Ticks;
                    string filePath = "/img/"+ imgFolder +"/" + fileName + ".jpeg";
                    image.Save(Server.MapPath("~" + filePath));
                    desc.ImageUrl = filePath;
                }
            }
            pageRepository.UpdatePage(page);
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