using System.Linq;
using System.Web.Mvc;
using DivingTracker.ServiceLayer;
using DivingTracker.Web.Attributes;
using DivingTracker.Web.Models;

namespace DivingTracker.Web.Controllers
{
    [Authorise]
    public class HomeController : DivingTrackerBaseController
    {
        public HomeController(DivingTrackerEntities databaseContext)
            : base(databaseContext)
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = new HomeModel(CurrentUser);

            return View(model);
        }
    }
}