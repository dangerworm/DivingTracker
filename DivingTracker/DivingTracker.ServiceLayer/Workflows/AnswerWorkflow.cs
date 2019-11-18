using System.Collections.Generic;
using System.Linq;
using CommonCode.BusinessLayer;
using CommonCode.BusinessLayer.Helpers;
using DivingTracker.ServiceLayer.DomainModels;
using DivingTracker.ServiceLayer.Entities;
using DivingTracker.ServiceLayer.Interfaces;
using DivingTracker.ServiceLayer.Repositories;

namespace DivingTracker.ServiceLayer.Workflows
{
    public class AnswerWorkflow
    {
        private readonly IValidator<AnswerDto> _answerValidator;

        private readonly AnswerRepository _answerRepository;
        private readonly QuestionRepository _questionRepository;
        private readonly UserRepository _userRepository;
        private readonly UserResponseRepository _userResponseRepository;

        public AnswerWorkflow(IValidator<AnswerDto> answerValidator, AnswerRepository answerRepository,
            QuestionRepository questionRepository, UserRepository userRepository,
            UserResponseRepository userResponseRepository)
        {
            Verify.NotNull(answerValidator, nameof(answerValidator));

            _answerValidator = answerValidator;

            Verify.NotNull(answerRepository, nameof(answerRepository));
            Verify.NotNull(questionRepository, nameof(questionRepository));
            Verify.NotNull(userRepository, nameof(userRepository));
            Verify.NotNull(userResponseRepository, nameof(userResponseRepository));

            _answerRepository = answerRepository;
            _questionRepository = questionRepository;
            _userRepository = userRepository;
            _userResponseRepository = userResponseRepository;
        }

        public DataResult<AnswerDto> Create(AnswerDto value)
        {
            var validationResult = _answerValidator.Validate(value);
            if (validationResult.Type != DataResultType.Success)
            {
                return validationResult;
            }

            var answer = value.Map<AnswerDto, Answer>();
            var createResult = _answerRepository.Create(answer, value.QuestionId);
            return createResult.Convert<Answer, AnswerDto>();
        }

        public DataResult<AnswerDto> Read(int answerId)
        {
            var answerResult = _answerRepository.Read(answerId);
            if (answerResult.Type != DataResultType.Success ||
                !answerResult.Value.AnswerId.HasValue)
            {
                return answerResult.Convert<Answer, AnswerDto>();
            }

            var answer = answerResult.Value.Map<Answer, AnswerDto>();

            var userResult = _userRepository.Read(answerResult.Value.UserId);
            if (userResult.Type != DataResultType.Success)
            {
                return userResult.Convert<User, AnswerDto>();
            }
            answer.User = userResult.Value.Map<User, UserDto>();

            var questionResult = AddQuestions(answer);
            if (questionResult.Type != DataResultType.Success)
            {
                return questionResult.Convert<IEnumerable<QuestionDto>, AnswerDto>();
            }

            return new DataResult<AnswerDto>(answer, answerResult);
        }

        public DataResult<IEnumerable<AnswerDto>> ReadAllByUserId(int userId)
        {
            var answersResult = _answerRepository.ReadAllByUserId(userId);
            if (answersResult.Type != DataResultType.Success ||
                !answersResult.Value.Any())
            {
                return answersResult.ConvertAll<Answer, AnswerDto>();
            }

            var answers = answersResult.Value
                .MapAll<Answer, AnswerDto>()
                .OrderByDescending(x => x.CreatedDate)
                .ToArray();

            var userResult = _userRepository.Read(userId);
            if (userResult.Type != DataResultType.Success)
            {
                return userResult.ConvertSingleToEnumerable<User, AnswerDto>();
            }

            var user = userResult.Value.Map<User, UserDto>();
            foreach (var answer in answers)
            {
                if (!answer.AnswerId.HasValue)
                {
                    continue;
                }

                answer.User = user;

                var questionResult = AddQuestions(answer);
                if (questionResult.Type != DataResultType.Success)
                {
                    return questionResult.ConvertAll<QuestionDto, AnswerDto>();
                }
            }

            return new DataResult<IEnumerable<AnswerDto>>(answers, answersResult);
        }

        public DataResult SubmitAnswer(int userId, int questionId, int answerId)
        {
            return _userResponseRepository.SubmitAnswer(userId, questionId, answerId);
        }

        private DataResult<IEnumerable<QuestionDto>> AddQuestions(AnswerDto answer)
        {
            if (!answer.AnswerId.HasValue)
            {
                return null;
            }

            var questionResult = _questionRepository.ReadAllByAnswerId(answer.AnswerId.Value);
            if (questionResult.Type != DataResultType.Success)
            {
                return questionResult.ConvertAll<Question, QuestionDto>();
            }

            var questions = questionResult.Value
                .OrderBy(x => x.QuestionText, new SemiNumericComparer())
                .MapAll<Question, QuestionDto>()
                .ToArray();

            answer.Questions = questions;
            return new DataResult<IEnumerable<QuestionDto>>(questions, questionResult);
        }
    }
}