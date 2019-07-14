using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BookReadingEvent
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "Events",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Event", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "Comments",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Comments", action = "Index", id = UrlParameter.Optional }
          );
            routes.MapRoute(
              name: "User",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional }
          );
        }
    }
}
