using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Restaurant.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                            "",
                            "Act-{action}/{id}",
                            new { controller = "Home", page = UrlParameter.Optional});

            routes.MapRoute(
                            "",
                            "Page/{page}",
                            new {controller = "Home", action = "Index"});

            routes.MapRoute(
                            name: "Default",
                            url: "{controller}/{action}",
                            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, page = UrlParameter.Optional}
            );
        }
    }
}