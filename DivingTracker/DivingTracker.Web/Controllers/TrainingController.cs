using System.Web.Mvc;
using DivingTracker.ServiceLayer;
using DivingTracker.Web.Attributes;
using DivingTracker.Web.Models;

namespace DivingTracker.Web.Controllers
{
    [Authorise]
    public class TrainingController : DivingTrackerBaseController
    {
        public TrainingController(DivingTrackerEntities databaseContext)
            : base(databaseContext)
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = new TrainingModel(DatabaseContext.Users, DatabaseContext.UserCriterions, DatabaseContext.ModuleSections, DatabaseContext.Modules);

            return View(model);
        }
    }
}