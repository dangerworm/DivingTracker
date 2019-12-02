using System;
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

        public ActionResult Enrol(int id)
        {
            var user = DatabaseContext.Users.Find(id);
            var qualifications =
                DatabaseContext.Qualifications.Where(x => !x.UserQualifications.Select(y => y.UserId)
                    .Contains(CurrentUserId));

            var model = new EnrolModel(user, qualifications);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Enrol(EnrolModel model)
        {
            var qualificationIds = model.EnrolPostModels
                .Where(x => x.Selected)
                .Select(x => x.Qualification.QualificationId);

            var criterionIds = DatabaseContext.Criteria
                .Where(x => qualificationIds.Contains(x.ModuleSection.Module.Qualification.QualificationId))
                .Select(x => x.CriterionId);

            foreach (var criterionId in criterionIds)
            {
                var newUserCriterion = new UserCriterion
                {
                    CriterionId = criterionId,
                    CriterionStatusId = (int)CriterionStatuses.NotStarted,
                    UserId = model.User.UserId,
                    UpdatedDate = DateTime.Now
                };

                DatabaseContext.UserCriterions.Add(newUserCriterion);
            }

            DatabaseContext.SaveChanges();

            return RedirectToAction("Details", "Members", new {id = model.User.UserId});
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
                    .Where(x => myCriteria.Any(y => y.Criterion.ModuleSection.Module.Qualification.QualificationId ==
                                                    x.QualificationId))
                    .ToArray();
            }

            foreach (var qualification in qualifications)
                model.Add(new TrainingModel(qualification));

            return View(model);
        }

        public ActionResult Qualification(int qualificationId)
        {
            var qualification = DatabaseContext.Qualifications.Find(qualificationId);

            var model = qualification == null
                ? new TrainingModel()
                : new TrainingModel(qualification);

            return View(model);
        }
    }
}