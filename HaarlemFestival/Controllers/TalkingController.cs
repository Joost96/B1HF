using HaarlemFestival.Model;
using HaarlemFestival.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaarlemFestival.Controllers
{
    public class TalkingController : Controller
    {
        private DBHF db;
        private IPageRepository pageRepo;
        private IActivityRepository activityRepo;
        private IQuestionRepository questionRepository;
        public TalkingController()
        {
            db = new DBHF();
            pageRepo = new PageRepository(db);
            activityRepo = new ActivityRepository(db);
            questionRepository = new QuestionRepository(db);

        }
        // GET: Talking
        public ActionResult Index()
        {
            PpApOpQ model = new PpApOpQ();
            
            Page page = pageRepo.GetPage("Talking", Language.Eng);            
            IEnumerable<Activity> activities = activityRepo.GetActivities(EventType.Talking, Language.Eng);

            activities.OrderBy(Activitie => Activitie.Timeslots);

            model.Page = page;
            model.Activities = activities.ToList();

            return View(model);
        }


        [HttpPost]
        public ActionResult AskQuestion(PpApOpQ model)
        {
            Question q = new Question();

            q.Message = model.Question.Message;
            q.Spreker = model.Question.Spreker;

            questionRepository.CreateQuestion(q);

            return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString());
        }

        [HttpPost]
        public ActionResult Order(PpApOpQ model)
        {
            Order order = (Order)Session["Order"];
            

            return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString());
        }







    }
}