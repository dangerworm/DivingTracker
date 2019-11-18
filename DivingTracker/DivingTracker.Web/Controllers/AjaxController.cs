using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using CommonCode.BusinessLayer;
using CommonCode.BusinessLayer.Helpers;
using DivingTracker.ServiceLayer.Entities;
using DivingTracker.ServiceLayer.Helpers;
using DivingTracker.ServiceLayer.Interfaces;
using DivingTracker.ServiceLayer.JsonModels;
using DivingTracker.Web.Attributes;
using HtmlAgilityPack;
using Microsoft.Ajax.Utilities;

namespace DivingTracker.Web.Controllers
{
    [Authorise]
    public class AjaxController : DivingTrackerBaseController
    {
        private readonly IQuestionService _questionService;
        private readonly ISearchService _searchService;

        public AjaxController(IUserService userService, IQuestionService questionService,
            ISearchService searchService)
            : base(userService)
        {
            Verify.NotNull(questionService, nameof(questionService));
            Verify.NotNull(searchService, nameof(searchService));

            _questionService = questionService;
            _searchService = searchService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchQuestions(string term)
        {
            var questionsResult = _questionService.Search(term);
            if (questionsResult.Type != DataResultType.Success)
            {
                return Json(new { success = false });
            }

            var model = questionsResult.Value.Select(x => 
                new
                {
                    id = x.QuestionId,
                    value = x.QuestionText,
                    label = x.QuestionText
                });
            return Json(model);
        }

        [HttpGet]
        public ActionResult GetSimilarQuestions(string term)
        {
            var questionsResult = _questionService.Search(term);
            if (questionsResult.Type != DataResultType.Success)
            {
                return Json(new { success = false });
            }

            var html = RenderPartialViewToString("_SimilarQuestions", questionsResult.Value);
            return Json(new {html}, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> SearchWikipedia(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return Json(new {success = false}, JsonRequestBehavior.AllowGet);
            }

            var searchResult = await _searchService.SearchWikipedia(query);
            if (searchResult.Type != DataResultType.Success ||
                (searchResult.Value?.query?.searchinfo?.totalhits ?? 0) == 0)
            {
                return Json(new {success = false}, JsonRequestBehavior.AllowGet);
            }

            var model = searchResult.Value;
            var html = RenderPartialViewToString("_WikipediaSearchResults", model);
            return Json(new { html }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> GetWikipediaContent(string pageId)
        {
            if (string.IsNullOrEmpty(pageId))
            {
                return Json(new {success = false}, JsonRequestBehavior.AllowGet);
            }

            var searchResult = await _searchService.ReadWikipediaPage(pageId);
            if (searchResult.Type != DataResultType.Success)
            {
                return Json(new {success = false}, JsonRequestBehavior.AllowGet);
            }

            var url = searchResult.Value.query.pages.FirstOrDefault().Value.fullurl;

            var page = WebHelper.GetHtmlDocument(url);
            if (page == null)
            {
                return Json(new {success = false}, JsonRequestBehavior.AllowGet);
            }

            // Cheating
            var rootNode = page.GetElementbyId("mw-content-text");
            var mwParserOutput = rootNode.ChildNodes.FirstOrDefault(x => x.Attributes.Any(y => y.Value == "mw-parser-output"));
            var content = mwParserOutput?.ChildNodes.FirstOrDefault(x => x.Name == "p" && !x.InnerText.IsNullOrWhiteSpace());

            var description = GetDescription(content);
            var html = content?
                .InnerHtml
                .Replace("href=\"/", "target=\"blank\" href=\"http://www.wikipedia.com/");

            return Json(new {description, content = html}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetChartData(int questionId, string chartType)
        {
            var analyticsResult = _questionService.GetAnalytics(questionId);
            if (analyticsResult.Type != DataResultType.Success)
            {
                return Json(new {success = false});
            }

            var data = analyticsResult.Value;
            var model = GetChartDataModel(data, chartType);
            return Json(model);
        }

        private ChartDataModelJdo GetChartDataModel(QuestionAnalyticsDto data, string chartType)
        {
            if (data.QuestionId == 0)
            {
                return null;
            }

            var chartModel = new ChartDataModelJdo
            {
                type = chartType,
                data = new ChartDataJdo
                {
                    labels = data.ResponseData.Select(x => x.AnswerText).ToArray(),
                    datasets = new[]
                    {
                        new ChartDataSetJdo
                        {
                            label = "Number of Responses",
                            data = data.ResponseData.Select(x => x.ResponseCount).ToArray()
                        }
                    }
                }
            };

            return chartModel;
        }

        private static string GetDescription(HtmlNode content)
        {
            if (string.IsNullOrWhiteSpace(content?.InnerHtml))
            {
                return null;
            }

            var description = string.Empty;
            var innerText = content.InnerText;
            var startWords = new[] {"is", "was", "are", "were"};
            var startIndices = new int[startWords.Length];

            for (var i = 0; i < startWords.Length; i++)
            {
                startIndices[i] = innerText.IndexOf(startWords[i], StringComparison.Ordinal);
            }

            try
            {
                if (startIndices.All(x => x == -1))
                {
                    return null;
                }

                var startIndex = startIndices.Where(x => x > -1).Min();
                var word = startWords[startIndices.ToList().IndexOf(startIndex)];

                startIndex += word.Length + 1;
                var firstFullStop = innerText.Substring(startIndex).IndexOf(".", StringComparison.Ordinal);
                description = innerText.Substring(startIndex, firstFullStop);

                return description.Substring(0, 1).ToUpper() + description.Substring(1);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}