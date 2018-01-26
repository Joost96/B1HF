using HaarlemFestival.Model;
using HaarlemFestival.Model.Helpers;
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
        private ITicketRepository ticketRepository;
        private Language language;

        public TalkingController()
        {
            db = new DBHF();
            pageRepo = new PageRepository(db);
            activityRepo = new ActivityRepository(db);
            questionRepository = new QuestionRepository(db);
            ticketRepository = new TicketRepository(db);
            

        }
        // GET: Talking
        public ActionResult Index()
        {
            language = (Language)Session["language"];

            PpApOpQ model = new PpApOpQ();
            
            Page page = pageRepo.GetPage("Talking", Language.Eng);            
            IEnumerable<Activity> activities = activityRepo.GetActivities(EventType.Talking, language);

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
            if (order == null) { order = new Order(); }
                

            Activity a = activityRepo.GetActivity(model.OHT.Ticket_TimeSlot_Activity_Id, language);
            model.OHT.Ticket_Type = TicketType.free;
            model.OHT.Ticket_TimeSlot_StartTime = a.Timeslots[0].StartTime;
            model.OHT.TotalPrice = 0;
            model.OHT.Ticket = ticketRepository.GetTicket(a, model.OHT.Ticket_TimeSlot_StartTime, model.OHT.Ticket_Type);
            order.OrderHasTickets.Add(model.OHT);
            Session["Order"] = order;

            BasketHelper.getInstance().checkBasket(HttpContext);

            return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString());
        }
    }
}