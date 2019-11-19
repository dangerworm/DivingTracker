using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CommonCode.BusinessLayer.Helpers;
using CommonCode.Web.Controllers;
using DivingTracker.ServiceLayer;

namespace DivingTracker.Web.Controllers
{
    public class DivingTrackerBaseController : BaseController
    {
        protected DivingTrackerEntities DatabaseContext;
        protected User CurrentUser { get; set; }
        protected int CurrentUserId { get; set; }

        public DivingTrackerBaseController(DivingTrackerEntities databaseContext)
        {
            Verify.NotNull(databaseContext, nameof(databaseContext));

            DatabaseContext = databaseContext;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            RedirectToLoginPageIfNotAuthenticated(filterContext);
            SetCurrentUser();

            ViewBag.SiteName = ConfigurationManager.AppSettings["SiteName"];
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;

            var httpException = filterContext.Exception as HttpException;
            if (httpException == null)
            {
                filterContext.Result = RedirectToAction("Index", "Errors");
                return;
            }

            switch (httpException.GetHttpCode())
            {
                case 401:
                    filterContext.Result = RedirectToAction("Error401", "Errors");
                    return;
                case 404:
                    filterContext.Result = RedirectToAction("Error404", "Errors");
                    return;
            }
        }

        private void RedirectToLoginPageIfNotAuthenticated(ActionExecutingContext filterContext)
        {
            var action = filterContext.ActionDescriptor.ActionName;
            var allowedActions = new[] { "Register", "Registered", "ConfirmEmail", "Login" };

            if (!User.Identity.IsAuthenticated && !allowedActions.Contains(action))
            {
                filterContext.Result = new RedirectResult("~/Authentication/Login");
            }
        }

        private void SetCurrentUser()
        {
            var authenticationCookie = Request?.Cookies[FormsAuthentication.FormsCookieName];
            if (authenticationCookie == null)
            {
                return;
            }
            var ticket = FormsAuthentication.Decrypt(authenticationCookie.Value);
            if (ticket == null)
            {
                return;
            }

            var systemLogin = DatabaseContext.SystemLogins.FirstOrDefault(x => x.EmailAddress.Equals(ticket.Name));
            if (systemLogin == null)
                return;

            var user = DatabaseContext.Users.FirstOrDefault(x => x.SystemLoginId == systemLogin.SystemLoginId);
            if (user == null)
                return;

            CurrentUser = user;
            CurrentUserId = user.UserId;

            ViewBag.CurrentUser = CurrentUser;
            ViewBag.CurrentUserId = CurrentUserId;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DatabaseContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}