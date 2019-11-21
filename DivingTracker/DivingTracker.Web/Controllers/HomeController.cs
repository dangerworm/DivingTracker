using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            var clubQualifications = new Dictionary<int, QualificationModel>();

            foreach (var qualification in qualifications)
            {
                if (!qualification.QualificationId.HasValue)
                    continue;

                var key = qualification.QualificationId.Value;

                if (clubQualifications.ContainsKey(key))
                {
                    clubQualifications[key].Count += 1;
                }
                else
                {
                    clubQualifications.Add(key, new QualificationModel(qualification.Qualification));
                }
            }

            var model = new HomeModel
            {
                User = CurrentUser,
                ClubQualifications = clubQualifications
            };

            return View(model);
        }
    }
}