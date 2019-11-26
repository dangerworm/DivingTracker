using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CommonCode.BusinessLayer;
using CommonCode.BusinessLayer.Helpers;
using DivingTracker.ServiceLayer;
using DivingTracker.ServiceLayer.DataTransferObjects;
using DivingTracker.ServiceLayer.Enums;
using DivingTracker.ServiceLayer.Interfaces;
using DivingTracker.Web.Attributes;
using DivingTracker.Web.Models;
using Newtonsoft.Json;

namespace DivingTracker.Web.Controllers
{
    [AllowAnonymous]
    public class AuthenticationController : DivingTrackerBaseController
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IEmailService _emailService;

        public AuthenticationController(DivingTrackerEntities databaseContext,
            IAuthenticationService authenticationService, IEmailService emailService)
            : base(databaseContext)
        {
            Verify.NotNull(authenticationService, nameof(authenticationService));
            Verify.NotNull(emailService, nameof(emailService));

            _authenticationService = authenticationService;
            _emailService = emailService;
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegistrationModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var request = model.Map<RegistrationModel, UserRegistrationRequestDto>();
            var registrationResult = _authenticationService.Register(request);
            if (registrationResult.Type != DataResultType.Success)
            {
                ModelState.AddModelError("", registrationResult.FriendlyMessage);
                return View();
            }

            var emailResult = _emailService.Send(EmailType.ConfirmEmail,
                new[] { registrationResult.Value.UserId });
            if (emailResult.Type != DataResultType.Success)
            {
                ModelState.AddModelError("", "We attempted to send an email to you so that " +
                                             "you can confirm your address, but it failed: " +
                                             $"{registrationResult.FriendlyMessage}");
                return View();
            }

            return RedirectToAction("Registered");
        }

        [HttpGet]
        public ActionResult Registered()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ConfirmEmail(Guid emailConfirmationToken)
        {
            var authenticationResult = _authenticationService.ConfirmEmail(emailConfirmationToken);
            if (authenticationResult.Type != DataResultType.Success)
            {
                ModelState.AddModelError("", $"The email address could not be confirmed: {authenticationResult.FriendlyMessage}");
            }

            DoLogin(authenticationResult.Value);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Password))
            {
                ModelState.AddModelError("", "The password field cannot be blank. Please try again.");
                return Login();
            }

            var authenticationResult = _authenticationService.Login(model.EmailAddress, model.Password);
            if (authenticationResult.Type != DataResultType.Success)
            {
                ModelState.AddModelError("", "The username and password combination was not recognised. Please try again.");
                return Login();
            }

            DoLogin(authenticationResult.Value);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorise]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }

        private void DoLogin(User user)
        {
            var systemLogin = DatabaseContext.SystemLogins.Find(user.SystemLoginId);
            if (systemLogin == null)
                return;

            var ticket = new FormsAuthenticationTicket(
                1, systemLogin.EmailAddress,
                DateTime.Now,
                DateTime.Now.AddDays(1),
                false,
                user.SystemRole.Description
            );

            var encryptedTicket = FormsAuthentication.Encrypt(ticket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

            Response.Cookies.Add(cookie);

            if (ticket.IsPersistent)
            {
                cookie.Expires = ticket.Expiration;
            }

            FormsAuthentication.SetAuthCookie(systemLogin.EmailAddress, false);
        }
    }
}