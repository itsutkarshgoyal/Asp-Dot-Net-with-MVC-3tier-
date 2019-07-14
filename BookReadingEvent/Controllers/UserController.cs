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
    public class UserController : Controller
    {
        [CustomAuthorize]
        public ActionResult Index()
        {
            List<UserDetail> users = new UserManager().showusers();
            if (users == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<UserDetailViewModel> targetList = users.Select(x => new UserDetailViewModel()
            {
                id = x.id,
                first_name = x.first_name,
                last_name = x.last_name,
                email = x.email,
                role = x.role,
                password = x.password,

            }).ToList();
            
            return View(targetList);
           
        }

        [CustomAuthorize]
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Login(UserDetailViewModel collection)
        {

            // TODO: Add insert logic here
            var user = new UserManager().LoginUser(collection).FirstOrDefault();
            UserDetail user_id = new UserManager().LoginUser(collection).FirstOrDefault();
            if (user != null)
            {
                Session["id"] = collection.email;
                Session["Logedin"] = "true";
                Session["role"] = user.role;
                Session["primary"] = user_id.id;
                
               return RedirectToAction("LoginUser", "Home", null);
             }
            else
            {
                ViewBag.Message = "Email or Password is wrong.";
                return View();
            }
        }
        [CustomAuthorize]
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index","Home");
           
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(UserDetailViewModel collection)
        {
            if (!( collection.role.ToString().Equals("admin") || collection.ToString().Equals("user")))
                collection.role = "user";
            var users = 0;
            try {
                users = new UserManager().SaveUser(collection); 
               // if (users == 1)
                return RedirectToAction("Index", "User");
        }
           catch(Exception ex)
            {
                ViewBag.Message = "User Already Exists";
                return View();
            }
        }
        [CustomAuthorize]
        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            List<UserDetail> users = new UserManager().showusers();
            List<UserDetailViewModel> targetList = users.Select(x => new UserDetailViewModel()
            {
                id = x.id,
                first_name = x.first_name,
                last_name = x.last_name,
                email = x.email,
                role = x.role,
                password = x.password,

            }).ToList();
            UserDetailViewModel model = targetList.FirstOrDefault();
            return View(model);
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(UserDetailViewModel collection)
        {
            try
            {
                // TODO: Add update logic here

                List<UserDetail> users = new UserManager().EditUser(collection);
                return RedirectToAction("Index", "User");
            }
            catch
            {
                ViewBag.Message = "Something Event Wrong Try again.";
                return View();
            }
        }
        [CustomAuthorize]
        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            List<UserDetail> user = new UserManager().showusers();
            List<UserDetailViewModel> targetList = user.Select(x => new UserDetailViewModel()
            {
                id = x.id,
                first_name = x.first_name,
                last_name = x.last_name,
                email = x.email,
                role = x.role,
                password = x.password,

            }).ToList();
            UserDetailViewModel model = targetList.FirstOrDefault();
            return View(model);
        }

        // POST: Login/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            try
            {
                // TODO: Add delete logic here

                var user = new UserManager().DeleteUser(id);
                return RedirectToAction("Index", "User");
            }
            catch
            {
                ViewBag.Message = "Something went wrong try again";
                return View();
            }
        }

        public ActionResult UnitTestMethod1()
        {
            return View();
        }

        public ActionResult UnitTestMethod2()
        {
            return View();
        }
    }
}
