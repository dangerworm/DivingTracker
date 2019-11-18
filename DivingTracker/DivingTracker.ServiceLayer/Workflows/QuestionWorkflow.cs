using System;
using System.Collections.Generic;
using System.Linq;
using CommonCode.BusinessLayer;
using CommonCode.BusinessLayer.Helpers;
using DivingTracker.ServiceLayer.DomainModels;
using DivingTracker.ServiceLayer.Entities;
using DivingTracker.ServiceLayer.Helpers;
using DivingTracker.ServiceLayer.Interfaces;
using DivingTracker.ServiceLayer.Repositories;

namespace DivingTracker.ServiceLayer.Workflows
{
    public class QuestionWorkflow
    {
        private readonly IValidator<QuestionDto> _questionValidator;

        private readonly QuestionRepository _questionRepository;
        private readonly QuestionAnalyticsRepository _questionAnalyticsRepository;
        private readonly UserResponseRepository _userResponseRepository;
        
        public QuestionWorkflow(IValidator<QuestionDto> questionValidator, QuestionRepository questionRepository, 
            QuestionAnalyticsRepository questionAnalyticsRepository,
            UserResponseRepository userResponseRepository)
        {
            Verify.NotNull(questionValidator, nameof(questionValidator));

            _questionValidator = questionValidator;

            Verify.NotNull(questionRepository, nameof(questionRepository));
            Verify.NotNull(questionAnalyticsRepository, nameof(questionAnalyticsRepository));
            Verify.NotNull(userResponseRepository, nameof(userResponseRepository));

            _questionRepository = questionRepository;
            _questionAnalyticsRepository = questionAnalyticsRepository;
            _userResponseRepository = userResponseRepository;
        }

        public DataResult<QuestionDto> Create(QuestionDto value)
        {
            var validationResult = _questionValidator.Validate(value);
            if (validationResult.Type == DataResultType.ValidationError)
            {
                return validationResult;
            }

            var question = value.Map<QuestionDto, Question>();
            var createResult = _questionRepository.Create(question);
            return createResult.Convert<Question, QuestionDto>();
        }

        public DataResult<QuestionDto> Read(int questionId, int userId)
        {
            var questionResult = _questionRepository.Read(questionId);
            if (questionResult.Type != DataResultType.Success ||
                !questionResult.Value.QuestionId.HasValue)
            {
                return questionResult.Convert<Question, QuestionDto>();
            }

            var question = questionResult.Value.Map<Question, QuestionDto>();
            question.User = questionResult.Value.User.Map<User, UserDto>();
            question.Answers = questionResult.Value.Answers
                .MapAll<Answer, AnswerDto>().ToArray();

            var responseResult = _userResponseRepository.ReadByUserAndQuestionId(userId, questionId);
            var response = responseResult.Value;

            if (response != null && question.Answers.Any(x => x.AnswerId == response.AnswerId))
            {
                question.Answers
                    .First(x => x.AnswerId == response.AnswerId)
                    .IsSelected = true;
            }

            var analyticsResult = GetAnalytics(questionId);
            if (analyticsResult.Type != DataResultType.Success)
            {
                return analyticsResult.Convert<QuestionAnalyticsDto, QuestionDto>();
            }
            question.Analytics = analyticsResult.Value;
            
            return new DataResult<QuestionDto>(question, questionResult);
        }

        public DataResult<IEnumerable<QuestionDto>> ReadAll(int userId, int? numberOfResults,
            DateTime? startDate, DateTime? endDate)
        {
            return ReadAll(userId, null, numberOfResults, startDate, endDate);
        }

        public DataResult<IEnumerable<QuestionDto>> ReadAllByPopularity(int userId, 
            int? numberOfResults, DateTime? startDate, DateTime? endDate)
        {
            return ReadAll(userId, x => x.ResponseCount, numberOfResults, startDate, endDate);
        }

        public DataResult<IEnumerable<QuestionDto>> ReadAllByResponseTime(int userId, 
            int? numberOfResults, DateTime? startDate, DateTime? endDate)
        {
            return ReadAll(userId, x => x.LastResponseTime, numberOfResults, startDate, endDate);
        }

        public DataResult<IEnumerable<QuestionDto>> ReadAllByUserId(int userId)
        {
            var questionsResult = _questionRepository.ReadAllByUserId(userId);
            return ProcessQuestionsResult(userId, questionsResult, x => x.CreatedDate);
        }

        public DataResult<QuestionDto> Save(QuestionDto value)
        {
            var question = value.Map<QuestionDto, Question>();

            var questionResult = _questionRepository.Save(question);
            if (questionResult.Type != DataResultType.Success ||
                !questionResult.Value.QuestionId.HasValue)
            {
                return questionResult.Convert<Question, QuestionDto>();
            }

            return Read(questionResult.Value.QuestionId.Value, value.UserId);
        }

        public DataResult<QuestionAnalyticsDto> GetAnalytics(int questionId)
        {
            var analyticsResult = _questionAnalyticsRepository.ReadAllByQuestionId(questionId);
            var groupedData = analyticsResult.Value.GroupBy(x => x.QuestionId).FirstOrDefault();
            if (analyticsResult.Type != DataResultType.Success || groupedData == null)
            {
                analyticsResult.Type = DataResultType.Success;
                return new DataResult<QuestionAnalyticsDto>(new QuestionAnalyticsDto(), analyticsResult);
            }

            var responseData = new List<ResponseData>();

            foreach (var data in groupedData)
            {
                responseData.Add(new ResponseData
                {
                    AnswerId = data.AnswerId,
                    AnswerText = data.AnswerText,
                    ResponseCount = data.ResponseCount
                });
            }

            var analytics = new QuestionAnalyticsDto
            {
                QuestionId = groupedData.Key,
                ResponseData = responseData
            };

            return new DataResult<QuestionAnalyticsDto>(analytics, analyticsResult);
        }

        public DataResult<IEnumerable<QuestionDto>> Search(string term)
        {
            var questionsResult = _questionRepository.Search(term);
            return questionsResult.ConvertAll<Question, QuestionDto>();
        }

        private DataResult<IEnumerable<QuestionDto>> ReadAll(int userId,
            Func<Question, object> orderByDescendingFunc, int? numberOfResults = null,
            DateTime? startDate = null, DateTime? endDate = null)
        {
            var questionsResult = _questionRepository.ReadAll(numberOfResults, startDate, endDate);
            return ProcessQuestionsResult(userId, questionsResult, orderByDescendingFunc);
        }

        private DataResult<IEnumerable<QuestionDto>> ProcessQuestionsResult(
            int userId, DataResult<IEnumerable<Question>> questionsResult,
            Func<Question, object> orderByDescendingFunc)
        {
            if (questionsResult.Type != DataResultType.Success ||
                !questionsResult.Value.Any())
            {
                return questionsResult.ConvertAll<Question, QuestionDto>();
            }

            var questions = questionsResult.Value;
            if (orderByDescendingFunc != null)
            {
                questions = questions.OrderByDescending(orderByDescendingFunc);
            }
                
            var questionDtos = questions
                .MapAll<Question, QuestionDto>()
                .ToArray();

            var responsesResult = _userResponseRepository.ReadAllByUserId(userId);
            var responses = responsesResult.Value.ToArray();

            foreach (var question in questionDtos)
            {
                if (!question.QuestionId.HasValue)
                {
                    continue;
                }

                question.User = questionsResult.Value
                    .FirstOrDefault(x => x.QuestionId == question.QuestionId)?
                    .User.Map<User, UserDto>();

                question.Answers = questionsResult.Value
                    .FirstOrDefault(x => x.QuestionId == question.QuestionId)?
                    .Answers.MapAll<Answer, AnswerDto>()
                    .ToArray();

                if (question.Answers != null && question.Answers.Any())
                {
                    var response = responses.FirstOrDefault(x => x.QuestionId == question.QuestionId);
                    if (response != null &&
                        question.Answers.Any(x => x.AnswerId == response.AnswerId))
                    {
                        question.Answers
                            .First(x => x.AnswerId == response.AnswerId)
                            .IsSelected = true;
                    }
                }

                var analyticsResult = GetAnalytics(question.QuestionId.Value);
                if (analyticsResult.Type != DataResultType.Success)
                {
                    return analyticsResult.ConvertSingleToEnumerable<QuestionAnalyticsDto, QuestionDto>();
                }

                question.Analytics = analyticsResult.Value;

                if (question.Analytics.ResponseData == null)
                {
                    question.Analytics.ResponseData = Enumerable.Empty<ResponseData>();
                }
            }

            return new DataResult<IEnumerable<QuestionDto>>(questionDtos, questionsResult);
        }
    }
}
