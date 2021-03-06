﻿using HaarlemFestival.Model;
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
        private DBHF db;
        private IPageRepository pageRepository;

        public ContactController()
        {
            db = new DBHF();
            pageRepository = new PageRepository(db);
        }

        // GET: Contact
        public ActionResult Index()
        {
            Language language = (Language)Session["language"];
            Page page = pageRepository.GetPage("Contact", language);

            return View(page);
        }
    }
}