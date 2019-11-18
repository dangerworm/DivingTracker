using System.Web.Mvc;
using CommonCode.BusinessLayer;
using CommonCode.BusinessLayer.Helpers;
using DivingTracker.ServiceLayer.Entities;
using DivingTracker.ServiceLayer.Interfaces;
using DivingTracker.Web.Attributes;

namespace DivingTracker.Web.Controllers
{
    [Authorise]
    public class QuestionController : DivingTrackerBaseController
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IUserService userService, 
                                  IQuestionService questionService)
            : base (userService)
        {
            Verify.NotNull(questionService, nameof(questionService));

            _questionService = questionService;
        }

        [HttpGet]
        public ActionResult Index(int id)
        {
            var result = _questionService.Read(id, CurrentUserId);
            if (result.Type != DataResultType.Success)
            {
                return HttpNotFound();
            }

            var question = result.Value;
            return View(question);
        }

        [HttpGet]
        public ActionResult Create(string questionText)
        {
            if (!Request.IsAjaxRequest())
            {
                return RedirectToAction("Index");
            }

            var model = new QuestionDto(CurrentUserId, questionText);
            return PartialView("_AddQuestion", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(QuestionDto model)
        {
            model.UserId = CurrentUserId;
            var result = _questionService.Create(model);

            if (result.Type == DataResultType.Success)
            {
                return result.Value.QuestionId.HasValue 
                    ? Json(new { success = true, url = "/Question/" + result.Value.QuestionId })
                    : Json(new { success = true });
            }

            if (result.Type == DataResultType.ValidationError)
            {
                foreach (string key in result.Validation.Keys)
                {
                    ModelState.AddModelError(key, result.Validation[key]);
                }
                var html = RenderPartialViewToString("_AddQuestion", model);
                return Json(new { success = false, html });
            }

            ModelState.AddModelError("", $"The question could not be created: {result.FriendlyMessage}");
            return Redirect(Request.Headers["Origin"]);
        }

        [HttpGet]
        public ActionResult Edit(int questionId)
        {
            if (!Request.IsAjaxRequest())
            {
                return RedirectToAction("Index", new {id = questionId});
            }

            var questionResult = _questionService.Read(questionId, CurrentUserId);
            if (questionResult.Type == DataResultType.Success)
            {
                return PartialView("_EditQuestion", questionResult.Value);
            }

            ModelState.AddModelError("", $"The question could not be loaded: {questionResult.FriendlyMessage}");
            return Redirect(Request.Headers["Origin"]);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(QuestionDto model)
        {
            model.UserId = CurrentUserId;
            var result = _questionService.Update(model);

            if (result.Type == DataResultType.Success)
            {
                return Json(new { success = true });
            }

            ModelState.AddModelError("", $"The question could not be edited: {result.FriendlyMessage}");
            return Redirect(Request.Headers["Origin"]);
        }
    }
}