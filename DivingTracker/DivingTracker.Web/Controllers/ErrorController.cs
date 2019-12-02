using System.Web.Mvc;
using DivingTracker.ServiceLayer;

namespace DivingTracker.Web.Controllers
{
    [AllowAnonymous]
    public class ErrorController : DivingTrackerBaseController
    {
        public ErrorController(DivingTrackerEntities databaseContext)
            : base(databaseContext)
        {
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

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}