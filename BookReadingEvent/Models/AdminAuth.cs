using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookReadingEvent.Models
{
    public class AdminAuth : System.Web.Mvc.ActionFilterAttribute, System.Web.Mvc.IActionFilter
    {
       

        public override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {
            String role = HttpContext.Current.Session["role"].ToString().TrimEnd();
            if (role.Equals("user"))
            {
                filterContext.Result = new System.Web.Mvc.RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
                {
                    {"Controller", "User"},
                    {"Action", "Login"},
                    {"id","1" }

                });
            }
            base.OnActionExecuting(filterContext);
        }
    }
}