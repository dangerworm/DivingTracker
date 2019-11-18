using System.Linq;
using System.Web.Mvc;
using CommonCode.BusinessLayer;
using CommonCode.BusinessLayer.Helpers;
using DivingTracker.ServiceLayer.Interfaces;
using DivingTracker.Web.Attributes;
using DivingTracker.Web.Models;

namespace DivingTracker.Web.Controllers
{
    [Authorise]
    public class HomeController : DivingTrackerBaseController
    {
        private readonly IQuestionService _questionService;

        public HomeController(IUserService userService,
                              IQuestionService questionService) 
            : base(userService)
        {
            Verify.NotNull(questionService, nameof(questionService));

            _questionService = questionService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = new DashboardModel
            {
                User = CurrentUser
            };

            var allQuestionsResult = _questionService.ReadAllByResponseTime(CurrentUserId, 20);
            if (allQuestionsResult.Type != DataResultType.Success)
            {
                ModelState.AddModelError("", allQuestionsResult.FriendlyMessage);
                return View(model);
            }
            model.Questions = allQuestionsResult.Value.Take(30);

            var topQuestionsResult = _questionService.ReadAllByPopularity(CurrentUserId);
            if (topQuestionsResult.Type != DataResultType.Success)
            {
                ModelState.AddModelError("", topQuestionsResult.FriendlyMessage);
                return View(model);
            }
            model.TopQuestions = topQuestionsResult.Value;

            if (TempData["ModelState"] != null)
            {
                ModelState.Merge((ModelStateDictionary)TempData["ModelState"]);
            }

            return View(model);
        }
    }
}