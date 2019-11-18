using System;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using CommonCode.Web.Infrastructure;
using DivingTracker.Web.Infrastructure;
using Microsoft.ApplicationInsights.Extensibility;

namespace DivingTracker.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            TelemetryConfiguration.Active.DisableTelemetry = true;

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = WindsorContainerFactory.Current(new ServiceInstaller());
            var castleControllerFactory = new WindsorControllerFactory(container);

            ControllerBuilder.Current.SetControllerFactory(castleControllerFactory);
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs eventArgs)
        {
            AuthenticateCookie();
        }

        protected void Application_Error(object sender, EventArgs eventArgs)
        {
            var exception = Server.GetLastError();

            var httpException = exception as HttpException;
            if (httpException == null)
            {
                Response.Redirect("~/Error/Index");
                return;
            }

            switch (httpException.GetHttpCode())
            {
                case 401:
                    Response.Redirect("~/Error/Error401");
                    return;
                case 404:
                    Response.Redirect("~/Error/Error404");
                    return;
            }
        }

        private void AuthenticateCookie()
        {
            var authenticationCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (!FormsAuthentication.CookiesSupported || authenticationCookie == null)
            {
                return;
            }

            try
            {
                var ticket = FormsAuthentication.Decrypt(authenticationCookie.Value);
                if (ticket == null)
                {
                    return;
                }

                var username = ticket.Name;
                var identity = new GenericIdentity(username, "DivingTrackerUser");
                Context.User = new GenericPrincipal(identity, new[] { "All" });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
