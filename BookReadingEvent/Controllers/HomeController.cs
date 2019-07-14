using BussinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using System.Net;
using BookReadingEvent.Models;
using BookReadingEventViewModel;

namespace BookReadingEvent.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<EventDetail> events = new EventManager().GetAllEvents();
            List<EventDetailViewModel> targetList = events.Select(x => new EventDetailViewModel()
            {
                created_by = x.created_by,
                description = x.description,
                Event_id = x.Event_id,
                duration = x.duration,
                location = x.location,
                title = x.title,
                type = x.type,
                start_time = x.start_time,
                other_details = x.other_details,
                invitation = x.invitation
            }).ToList();
            return View(targetList);
        }

        [CustomAuthorize]
        public  ActionResult LoginUser()
        {
            List<EventDetail> events = new EventManager().GetAllEvents();
            List<EventDetailViewModel> targetList = events.Select(x => new EventDetailViewModel()
            {
                created_by = x.created_by,
                description = x.description,
                Event_id = x.Event_id,
                duration = x.duration,
                location = x.location,
                title = x.title,
                type = x.type,
                start_time = x.start_time,
                other_details = x.other_details,
                invitation = x.invitation
            }).ToList();
            return View(targetList);
            
        }

        public ActionResult Details(int? id)
        {
            List<EventDetail> events = new EventManager().ViewEvents(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (events == null)
            {
                return HttpNotFound();
            }
            List<EventDetailViewModel> targetList = events.Select(x => new EventDetailViewModel()
            {
                created_by = x.created_by,
                description = x.description,
                Event_id = x.Event_id,
                duration = x.duration,
                location = x.location,
                title = x.title,
                type = x.type,
                start_time = x.start_time,
                other_details = x.other_details,
                invitation = x.invitation
            }).ToList();
            ViewBag.Message= new EventController().Createdby(targetList.FirstOrDefault().created_by);
            return View(targetList);
        }

        public ActionResult upevent()
        {
            DateTime now = DateTime.Now;
            List<EventDetail> events = new EventManager().upSearch(now);
            List<EventDetailViewModel> targetList = events.Select(x => new EventDetailViewModel()
            {
                created_by = x.created_by,
                description = x.description,
                Event_id = x.Event_id,
                duration = x.duration,
                location = x.location,
                title = x.title,
                type = x.type,
                start_time = x.start_time,
                other_details = x.other_details,
                invitation = x.invitation
            }).ToList();
            return View(targetList);
        }
        public ActionResult pastevent()
        {
            DateTime now = DateTime.Now;
            List<EventDetail> events = new EventManager().pastSearch(now);
            List<EventDetailViewModel> targetList = events.Select(x => new EventDetailViewModel()
            {
                created_by = x.created_by,
                description = x.description,
                Event_id = x.Event_id,
                duration = x.duration,
                location = x.location,
                title = x.title,
                type = x.type,
                start_time = x.start_time,
                other_details = x.other_details,
                invitation = x.invitation
            }).ToList();
            return View(targetList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Book reading sessions, where authors turn storytellers.";

            return View();
        }

        public ActionResult comments(int ?id)
        {
            List<comment> comments = new EventManager().showcomments(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (comments == null)
            {
                return HttpNotFound();
            }
            List<CommentsViewModel> targetList = comments.Select(x => new CommentsViewModel()
            {
                created_by = x.created_by,
                description = x.description,
                Event_id = x.Event_id,
                created_on = x.created_on,
                modified_on = x.modified_on,
                Id = x.Id,

            }).ToList();

            return View(targetList);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return RedirectPermanent("http://helpdesk.nagarro.com");
        }
    }
}