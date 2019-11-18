using System.Web.Mvc;
using DivingTracker.ServiceLayer.Interfaces;
using DivingTracker.Web.Attributes;

namespace DivingTracker.Web.Controllers
{
    [Authorise]
    public class HelpController : DivingTrackerBaseController
    {
        public HelpController(IUserService userService) 
            : base(userService)
        {
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}