using System.Web.Mvc;
using System.Web.Routing;

namespace DivingTracker.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Register",
                "Register",
                new {controller = "Authentication", action = "Register", id = string.Empty}
            );

            routes.MapRoute(
                "Login",
                "Login",
                new {controller = "Authentication", action = "Login", id = string.Empty}
            );

            routes.MapRoute(
                "Logout",
                "Logout",
                new {controller = "Authentication", action = "Logout", id = string.Empty}
            );

            routes.MapRoute(
                "Index",
                "{controller}/{id}",
                new {controller = "Home", action = "Index", id = string.Empty},
                new {id = @"^[0-9]+$"}
            );

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new {controller = "Home", action = "Index", id = UrlParameter.Optional}
            );
        }
    }
}