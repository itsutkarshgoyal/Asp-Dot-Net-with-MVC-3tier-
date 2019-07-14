using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookReadingEvent.Models;
using BookReadingEventViewModel;
using BussinessLayer;
using DataLayer;

namespace BookReadingEvent.Controllers
{
    public class CommentsController : Controller
    {
        // GET: Comments
        [Authorize]
        public ActionResult Index(int ?id)
        {
            if (Session["role"].ToString().TrimEnd().Equals("user"))
            {
                Boolean validate = this.ValidateComment(id);
                if (validate == false)
                {
                    return RedirectToAction("Index", "Event");
                }
            }
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
            ViewBag.Message = id;
            return View(targetList);
        }

        // GET: Comments/Details/5
        public ActionResult Details(int id)
        {
            if (Session["role"].ToString().TrimEnd().Equals("user"))
            {
                Boolean validate = this.Validate(id);
                if (validate == false)
                {
                    return RedirectToAction("Index", "Event");
                }
            }
            List<comment> events = new CommentManager().ViewComments(id);
            List<CommentsViewModel> targetList = events.Select(x => new CommentsViewModel()
            {
                created_by = x.created_by,
                description = x.description,
                Event_id = x.Event_id,
                created_on = x.created_on,
                modified_on = x.modified_on,
                Id = x.Id,

            }).ToList();
            CommentsViewModel model = targetList.FirstOrDefault();
            return View(model);
           // return View(events);
          
        }

        // GET: Comments/Create
        [CustomAuthorize]
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: Comments/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Event_id,description,created_on,modified_on,created_by")]CommentsViewModel collection)
        {
            try
            {
                collection.modified_on = DateTime.Now;
                collection.created_on = DateTime.Now;
                collection.created_by = Convert.ToInt32(Session["primary"]);
                collection.Event_id =Convert.ToInt32(Request.Url.Segments.Last());
                var events = new CommentManager().SaveComments(collection);
                //if(events ==1)
                return RedirectToAction("Index","Event");
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Something Event Wrong try Again.";
                return View();
            }
        }

        // GET: Comments/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["role"].ToString().TrimEnd().Equals("user"))
            {
                Boolean validate = this.Validate(id);
                if (validate == false)
                {
                    return RedirectToAction("Index", "Event");
                }
            }
            List<comment> events = new CommentManager().ViewComments(id);
            List<CommentsViewModel> targetList = events.Select(x => new CommentsViewModel()
            {
                created_by = x.created_by,
                description = x.description,
                Event_id = x.Event_id,
                created_on = x.created_on,
                modified_on = x.modified_on,
                Id = x.Id,

            }).ToList();
            CommentsViewModel model = targetList.FirstOrDefault();
            return View(model);
        }

        // POST: Comments/Edit/5
        [HttpPost]
        public ActionResult Edit(CommentsViewModel collection)
        {
            try
            {
                // TODO: Add update logic here
                List<comment> events = new CommentManager().EditComments(collection);
                
                return RedirectToAction("Index","Event");

            }
            catch(Exception ex)
            {
                ViewBag.Message = "Something Event Wrong try Again.";
                return View();
            }
        }

        // GET: Comments/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["role"].ToString().TrimEnd().Equals("user"))
            {
                Boolean validate = this.Validate(id);
                if (validate == false)
                {
                    return RedirectToAction("Index", "Event");
                }
            }
            List<comment> events = new CommentManager().ViewComments(id);
            List<CommentsViewModel> targetList = events.Select(x => new CommentsViewModel()
            {
                created_by = x.created_by,
                description = x.description,
                Event_id = x.Event_id,
                created_on = x.created_on,
                modified_on = x.modified_on,
                Id = x.Id,

            }).ToList();
            CommentsViewModel model = targetList.FirstOrDefault();
            return View(model);
           
        }

        // POST: Comments/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            try
            {
                // TODO: Add delete logic here
                var events = new CommentManager().DeleteComments(id);
                return RedirectToAction("Index","Event");
            }
            catch
            {
                ViewBag.Message = "Something Event Wrong try Again.";
                return View();
            }
        }

        public Boolean Validate(int? CommentId)
        {
            Boolean flag = false;
            var UserId = Convert.ToInt32(Session["primary"]);
            var events = new CommentManager().ValidateUser(UserId, CommentId);
            if (events == 1)
                flag = true;
            return flag;
        }

        public Boolean ValidateComment(int? CommentId)
        {
            Boolean flag = false;
            var UserId = Convert.ToInt32(Session["primary"]);
            var events = new EventManager().ValidateUser(UserId, CommentId);
            if (events == 1)
                flag = true;
            return flag;
        }

        public ActionResult CommentsTestMethod2()
        {
            return View();
        }

        public ActionResult CommentsTestMethod3()
        {
            return View();
        }

        public ActionResult CommentsTestMethod4()
        {
            return View();
        }
    }
}
