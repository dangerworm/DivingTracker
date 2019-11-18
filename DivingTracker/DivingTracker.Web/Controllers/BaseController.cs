using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CommonCode.BusinessLayer;
using CommonCode.BusinessLayer.Helpers;
using DivingTracker.ServiceLayer.Entities;
using DivingTracker.ServiceLayer.Interfaces;
using CommonCode.Web.Controllers;

namespace DivingTracker.Web.Controllers
{
    public class DivingTrackerBaseController : BaseController
    {
        protected IUserService UserService;
        protected UserDto CurrentUser { get; set; }
        protected int CurrentUserId { get; set; }

        public DivingTrackerBaseController(IUserService userService)
        {
            Verify.NotNull(userService, nameof(userService));

            UserService = userService;
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
                filterContext.Result = RedirectToAction("Index", "Error");
                return;
            }

            switch (httpException.GetHttpCode())
            {
                case 401:
                    filterContext.Result = RedirectToAction("Error401", "Error");
                    return;
                case 404:
                    filterContext.Result = RedirectToAction("Error404", "Error");
                    return;
            }
        }

        private void RedirectToLoginPageIfNotAuthenticated(ActionExecutingContext filterContext)
        {
            var action = filterContext.ActionDescriptor.ActionName;
            var allowedActions = new[] {"Register", "Registered", "ConfirmEmail", "Login"};

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
            var userResult = UserService.ReadByEmailAddress(ticket.Name);
            if (userResult.Type != DataResultType.Success ||
                userResult.Value?.UserId == null)
            {
                return;
            }

            CurrentUser = UserService.Read(userResult.Value.UserId.Value).Value;
            CurrentUserId = userResult.Value.UserId.Value;

            ViewBag.CurrentUser = CurrentUser;
            ViewBag.CurrentUserId = CurrentUserId;
        }
    }
}