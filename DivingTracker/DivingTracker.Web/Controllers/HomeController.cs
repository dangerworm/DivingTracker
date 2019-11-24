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
            var qualificationsCompleted = DatabaseContext.UserQualifications.Where(x => x.UserId == CurrentUserId).Select(x => x.Qualification);

            var trainingModuleIds = DatabaseContext.UserCriterions.Select(x => x.Criterion.ModuleSection.Module.ModuleId);
            var qualifiactionsInProgress = DatabaseContext.Qualifications.Where(x => x.UserQualifications.All(y => y.UserId != CurrentUserId) && x.Modules.Any(y => trainingModuleIds.Contains(y.ModuleId)));

            var model = new UserQualificationsModel(CurrentUser, qualificationsCompleted, qualifiactionsInProgress);
            return View(model);
        }

        [HttpGet]
        public ActionResult Info()
        {
            var branch = DatabaseContext.Branches.Find(CurrentUser.BranchId);
            if (branch == null)
            {
                return HttpNotFound();
            }

            var model = new InfoModel(CurrentUser, branch);
            return View(model);
        }
    }
}