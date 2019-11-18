using System.Web.Mvc;
using DivingTracker.ServiceLayer.Interfaces;

namespace DivingTracker.Web.Controllers
{
    [AllowAnonymous]
    public class ErrorController : DivingTrackerBaseController
    {
        public ErrorController(IUserService userService) 
            : base(userService)
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Error401()
        {
            return RedirectToAction("Login", "Authentication");
        }

        [HttpGet]
        public ActionResult Error404()
        {
            return View();
        }
    }
}