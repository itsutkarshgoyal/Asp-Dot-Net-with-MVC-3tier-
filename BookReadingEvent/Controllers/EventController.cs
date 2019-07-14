using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BookReadingEvent.Models;
using BussinessLayer;
using DataLayer;
using BookReadingEventViewModel;
namespace BookReadingEvent.Controllers
{
    [CustomAuthorize]
    public class EventController : Controller
    {
        // GET: Event
        [AdminAuth]
        public ActionResult AdminIndex()
        {
           // id = Convert.ToInt32(Session["primary"]);
            List<EventDetail> events =new EventManager().ShowAllEvents();
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
            //return View(events);
            return View(targetList);

        }
        public ActionResult Index(int ?id)
        {
            if (Session["role"].ToString().TrimEnd().Equals("admin"))
                return RedirectToAction("AdminIndex");
                id = Convert.ToInt32(Session["primary"]);
            List<EventDetail> events = new EventManager().MyEvents(id);
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
            //return View(events);
            return View(targetList);

        }

        // GET: Event/Details/5
        public ActionResult Details(int id)
        {
            if (Session["role"].ToString().TrimEnd().Equals("user"))
            {
                Boolean validate = this.Validate(id);
                if (validate == false)
                {
                    return RedirectToAction("Index");
                }
            }
            List<EventDetail> events = new EventManager().ViewEvents(id);
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
            
            ViewBag.Message= this.Createdby(targetList.FirstOrDefault().created_by);

            //return View(events);
            return View(targetList);

        }

        // GET: Event/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        [HttpPost]
        public ActionResult Create(EventDetailViewModel collection)
        {
            
            try
            {
                collection.created_by = Convert.ToInt32(Session["primary"]);
                var invitation = new List<Invitation>();
                if (!(collection.type.Equals(" ") || collection.type.ToString().Equals("public") || collection.type.ToString().Equals("private")))
                    collection.type = "public";
                if (collection.start_time.ToString() == null || collection.start_time.ToString().Equals(" "))
                    collection.start_time = DateTime.Now;
                    
                if (collection.invitation != null)
                {
                    String[] email_lst = collection.invitation.ToString().Split(',');
                EventDetail lst;
                    foreach (String email in email_lst)
                    {
                        invitation.Add(new Invitation() { email = email });
                    }
                }

                collection.Invitations = invitation;

                var events = new EventManager().SaveEvents(collection);
               // if (events == 1)
                    return RedirectToAction("Index");
            }
           catch(Exception ex)
            {
                ViewBag.Message = "Something Event Wrong try Again.";
                return View();
            }
        }

        // GET: Event/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["role"].ToString().TrimEnd().Equals("user"))
            {
                Boolean validate = this.Validate(id);
                if (validate == false)
                {
                    return RedirectToAction("Index");
                }
            }
            List<EventDetail> events = new EventManager().ViewEvents(id).ToList();
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
            EventDetailViewModel lst = targetList.FirstOrDefault();
            //return View(events);
            return View(lst);
            
           
        }

        // POST: Event/Edit/5
        [HttpPost]
        public ActionResult Edit(EventDetailViewModel collection)
        {
            try
            {
                // TODO: Add update logic here
                List<EventDetail> events = new EventManager().EditEvents(collection);
                return RedirectToAction("Index");
               
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Something Event Wrong try Again.";
                return View(collection);
            }
        }

        public ActionResult Invitation()
        {
            
            String email = (Session["id"]).ToString();
            List<EventDetail> lst = new EventManager().Invitation(email);
            List<EventDetailViewModel> targetList = lst.Select(x => new EventDetailViewModel()
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
            //return View(events);
            return View(targetList);
           
        }
        // GET: Event/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["role"].ToString().TrimEnd().Equals("user"))
            {
                Boolean validate = this.Validate(id);
                if (validate == false)
                {
                    return RedirectToAction("Index");
                }
            }
            List<EventDetail> events = new EventManager().ViewEvents(id);
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
            //return View(events);
            return View(targetList);
           
           
        }

        // POST: Event/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            try
            {
                // TODO: Add delete logic here
                var events = new EventManager().DeleteEvents(id);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Something Event Wrong try Again.";
                
                List<EventDetail> events = new EventManager().ViewEvents(id);
                List<EventDetailViewModel> targetList = events.Select(x => new EventDetailViewModel()
                {
                    created_by =x.created_by,
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
                
                //return View(events);
                return View(targetList);
            }
        }

        public Boolean Validate(int? EventId)
        {
            var UserId = Convert.ToInt32(Session["primary"]);
            Boolean flag = false;
            if (Session["primary"] != null)
            {
                
                var events = new EventManager().ValidateUser(UserId, EventId);
                if (events == 1)
                    flag = true;
            }
            return flag;
        
        }

        public string Createdby(int?id)
        {
            String name = new UserManager().Createdby(id);
            return name;
        }

      
    }
}
