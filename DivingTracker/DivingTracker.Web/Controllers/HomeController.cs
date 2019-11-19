using System.Collections.Generic;
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
            var clubQualifications = new Dictionary<string, int>();

            foreach (var qualification in qualifications)
            {
                var key = qualification.Qualification.Name;

                if (clubQualifications.ContainsKey(key))
                {
                    clubQualifications[key] += 1;
                }
                else
                {
                    clubQualifications.Add(key, 1);
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