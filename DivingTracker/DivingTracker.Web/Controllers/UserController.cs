using System.Web.Mvc;
using CommonCode.BusinessLayer;
using CommonCode.BusinessLayer.Helpers;
using DivingTracker.ServiceLayer.Interfaces;
using DivingTracker.Web.Attributes;
using DivingTracker.Web.Models;

namespace DivingTracker.Web.Controllers
{
    [Authorise]
    public class UserController : DivingTrackerBaseController
    {
        private readonly IQuestionService _questionService;
        private readonly IAnswerService _answerService;

        public UserController(IUserService userService, IQuestionService questionService,
            IAnswerService answerService)
            :base (userService)
        {
            Verify.NotNull(questionService, nameof(questionService));
            Verify.NotNull(answerService, nameof(answerService));

            _questionService = questionService;
            _answerService = answerService;
        }

        [HttpGet]
        [Authorise]
        public ActionResult Index(int id)
        {
            var model = GetProfileModel(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        private ProfileModel GetProfileModel(int userId)
        {
            var userResult = UserService.Read(userId);
            var questionResult = _questionService.ReadAllByUserId(userId);
            var answerResult = _answerService.ReadAllByUserId(userId);
            var responsesResult = UserService.GetResponses(userId);

            if (userResult.Type != DataResultType.Success ||
                responsesResult.Type != DataResultType.Success ||
                questionResult.Type != DataResultType.Success ||
                answerResult.Type != DataResultType.Success)
            {
                return null;
            }

            return new ProfileModel
            {
                User = userResult.Value,
                Questions = questionResult.Value,
                Answers = answerResult.Value,
                Responses = responsesResult.Value
            };
        }
    }
}