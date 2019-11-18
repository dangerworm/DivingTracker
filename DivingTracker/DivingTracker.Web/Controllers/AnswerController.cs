using System.Web.Mvc;
using CommonCode.BusinessLayer;
using CommonCode.BusinessLayer.Helpers;
using DivingTracker.ServiceLayer.Entities;
using DivingTracker.ServiceLayer.Interfaces;
using DivingTracker.Web.Attributes;

namespace DivingTracker.Web.Controllers
{
    [Authorise]
    public class AnswerController : DivingTrackerBaseController
    {
        private readonly IAnswerService _answerService;

        public AnswerController(IUserService userService, 
                                IQuestionService questionService,
                                IAnswerService answerService)
            : base(userService)
        {
            Verify.NotNull(answerService, nameof(answerService));

            _answerService = answerService;
        }

        [HttpGet]
        public ActionResult Index(int id)
        {
            var result = _answerService.Read(id);
            if (result.Type != DataResultType.Success)
            {
                return HttpNotFound();
            }

            var answer = result.Value;
            return View(answer);
        }

        [HttpGet]
        public ActionResult Create(int questionId)
        {
            if (!Request.IsAjaxRequest())
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new AnswerDto(CurrentUserId, questionId);
            return PartialView("_AddAnswer", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AnswerDto model)
        {
            model.UserId = CurrentUserId;
            var result = _answerService.Create(model);

            if (result.Type == DataResultType.Success)
            {
                return Json(new { success = true });
            }

            if (result.Type == DataResultType.ValidationError)
            {
                foreach (string key in result.Validation.Keys)
                {
                    ModelState.AddModelError(key, result.Validation[key]);
                }
                var html = RenderPartialViewToString("_AddAnswer", model);
                return Json(new { success = false, html });
            }

            ModelState.AddModelError("", $"The answer could not be created: {result.FriendlyMessage}");
            return Redirect(Request.Headers["Origin"]);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Submit(int questionId, int answerId)
        {
            if (answerId == -1)
            {
                return Create(questionId);
            }

            var result = _answerService.SubmitAnswer(CurrentUserId, questionId, answerId);

            if (result.Type != DataResultType.Success)
            {
                ModelState.AddModelError("", result.FriendlyMessage);
                TempData["ModelState"] = ModelState;
            }
            else if (Request.IsAjaxRequest())
            {
                return Json(new {@class = "btn btn-default ajax-submit"});
            }

            return RedirectToAction("Index", "Home");
        }
    }
}