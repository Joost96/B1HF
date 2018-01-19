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
        private IOrderRepository orderRepository;
        private IQuestionRepository questionRepository;
        public TalkingController()
        {
            db = new DBHF();
            pageRepo = new PageRepository(db);
            activityRepo = new ActivityRepository(db);
            orderRepository = new OrderRepository(db);
            questionRepository = new QuestionRepository(db);

        }
        // GET: Talking
        public ActionResult Index()
        {
            PagePlusActivities PagePLusActivities = new PagePlusActivities();
            
            Page page = pageRepo.GetPage("Talking", Language.Eng);            
            IEnumerable<Activity> activities = activityRepo.GetActivities(EventType.Talking, Language.Eng);

            activities.OrderBy(Activitie => Activitie.Timeslots);

            PagePLusActivities.Page = page;
            PagePLusActivities.Activities = activities.ToList();

            return View(PagePLusActivities);
        }


        [HttpPost]
        public ActionResult AskQuestion(PagePlusActivities pagePLusActivities)
        {
            Question q = new Question();

            q.Message = pagePLusActivities.Question.Message;
            q.Spreker = pagePLusActivities.Question.Spreker;

            questionRepository.CreateQuestion(q);

            return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString());
        }

        





    }
}