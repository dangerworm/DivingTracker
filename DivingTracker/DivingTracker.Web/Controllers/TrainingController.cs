using System.Collections.ObjectModel;
using System.Linq;
using System.Web.Mvc;
using DivingTracker.ServiceLayer;
using DivingTracker.ServiceLayer.Enums;
using DivingTracker.Web.Attributes;
using DivingTracker.Web.Models;

namespace DivingTracker.Web.Controllers
{
    [Authorise]
    [AuthoriseRoles(SystemRoles.Instructor, SystemRoles.Admin)]
    public class TrainingController : DivingTrackerBaseController
    {
        public TrainingController(DivingTrackerEntities databaseContext)
            : base(databaseContext)
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            var qualifications = DatabaseContext.Qualifications.ToArray();
            var model = new Collection<TrainingModel>();

            if (CurrentUser.SystemRole.SystemRoleId < (int)SystemRoles.Instructor)
            {
                var myCriteria = DatabaseContext.UserCriterions.Where(x => x.UserId == CurrentUserId);
                qualifications = qualifications
                    .Where(x => myCriteria.Any(y => y.Criterion.ModuleSection.Module.Qualification.QualificationId == x.QualificationId))
                    .ToArray();
            }

            foreach (var qualification in qualifications)
            {
                model.Add(new TrainingModel(qualification));
            }

            return View(model);
        }

        public ActionResult Qualification(int qualificationId)
        {
            var qualification = DatabaseContext.Qualifications.Find(qualificationId);
            //var criterionIds = qualification.Modules
            //    .SelectMany(x => x.ModuleSections.SelectMany(
            //        y => y.Criteria.SelectMany(
            //            z => z.UserCriterias)))
            //    .Select(x => x.CriterionId ?? -1);

            //var userCriteria = DatabaseContext.UserCriterions.Where(x => criterionIds.Contains(x.CriterionId))

            var model = qualification == null
                ? new TrainingModel()
                : new TrainingModel(qualification);

            return View(model);
        }
    }
}