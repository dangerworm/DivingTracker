using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

namespace DivingTracker.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Register",
                url: "Register",
                defaults: new { controller = "Authentication", action = "Register", id = string.Empty }
            );

            routes.MapRoute(
                name: "Login",
                url: "Login",
                defaults: new { controller = "Authentication", action = "Login", id = string.Empty }
            );

            routes.MapRoute(
                name: "Logout",
                url: "Logout",
                defaults: new { controller = "Authentication", action = "Logout", id = string.Empty }
            );

            routes.MapRoute(
                name: "Index",
                url: "{controller}/{id}",
                defaults: new { controller = "Home", action = "Index", id = string.Empty },
                constraints: new { id = @"^[0-9]+$" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
