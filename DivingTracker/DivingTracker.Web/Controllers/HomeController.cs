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
            var qualifications = DatabaseContext.UserQualifications.OrderBy(x => x.QualificationId);
            var model = new HomeModel(CurrentUser, qualifications);

            return View(model);
        }

        
    }
}