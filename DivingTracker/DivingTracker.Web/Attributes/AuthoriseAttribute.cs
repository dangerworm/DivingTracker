using System;
using System.Web;
using System.Web.Mvc;
using CommonCode.BusinessLayer.Helpers;

namespace DivingTracker.Web.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthoriseAttribute : AuthorizeAttribute
    {
        public const string RedirectUrl = "~/Error/Unauthorised";

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            Verify.NotNull(httpContext, nameof(httpContext));

            return base.AuthorizeCore(httpContext);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);

            filterContext.Result = filterContext.RequestContext.HttpContext.User.Identity.IsAuthenticated
                ? new RedirectResult(RedirectUrl)
                : new RedirectResult("~/Authentication/Login");
        }
    }
}