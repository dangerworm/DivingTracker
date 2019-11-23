using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonCode.BusinessLayer.Helpers;
using DivingTracker.ServiceLayer;
using DivingTracker.ServiceLayer.Enums;

namespace DivingTracker.Web.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthoriseRolesAttribute : AuthorizeAttribute
    {
        private readonly SystemRoles[] _roles;

        public AuthoriseRolesAttribute(params SystemRoles[] roles)
        {
            _roles = roles;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            Verify.NotNull(httpContext, nameof(httpContext));

            var systemLogin = new DivingTrackerEntities().SystemLogins
                .FirstOrDefault(x => x.EmailAddress.Equals(httpContext.User.Identity.Name));

            return systemLogin?.Users.Any(x => _roles.Contains((SystemRoles)x.SystemRole.SystemRoleId)) ?? false;
        }
    }
}