using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcWebsite
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
                name: "ProjectRoute",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Projects", action = "Projects", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "ContactRoute",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Contact", action = "ContactMe", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "CommentRoute",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Comment", action = "CreateComment", id = UrlParameter.Optional }
            );
        }
    }
}
