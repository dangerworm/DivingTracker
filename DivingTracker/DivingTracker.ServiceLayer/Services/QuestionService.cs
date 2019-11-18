using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CommonCode.BusinessLayer;
using CommonCode.BusinessLayer.Helpers;
using CommonCode.BusinessLayer.Services;
using DivingTracker.ServiceLayer.Entities;
using DivingTracker.ServiceLayer.Helpers;
using DivingTracker.ServiceLayer.Interfaces;
using DivingTracker.ServiceLayer.Workflows;

namespace DivingTracker.ServiceLayer.Services
{
    public class QuestionService: ServiceBase<SqlConnection, SqlTransaction>, IQuestionService
    {
        private readonly QuestionWorkflow _questionWorkflow;

        public QuestionService(IUnitOfWork<SqlConnection, SqlTransaction> unitOfWork, 
                               QuestionWorkflow questionWorkflow)
            : base(unitOfWork)
        {
            Verify.NotNull(questionWorkflow, nameof(questionWorkflow));

            _questionWorkflow = questionWorkflow;
        }

        public DataResult<QuestionDto> Create(QuestionDto value)
        {
            UnitOfWork.Begin();

            var result = _questionWorkflow.Create(value);

            UnitOfWork.End();

            return result;
        }

        public DataResult<QuestionDto> Read(int questionId, int userId)
        {
            UnitOfWork.Begin();

            var question = _questionWorkflow.Read(questionId, userId);

            UnitOfWork.End();

            return question;
        }

        public DataResult<IEnumerable<QuestionDto>> ReadAllByPopularity(int userId,
            int? numberOfResults = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            UnitOfWork.Begin();

            var result = _questionWorkflow.ReadAllByPopularity(userId, numberOfResults, startDate, endDate);

            UnitOfWork.End();

            return result;
        }

        public DataResult<IEnumerable<QuestionDto>> ReadAllByResponseTime(int userId,
            int? numberOfResults = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            UnitOfWork.Begin();

            var result = _questionWorkflow.ReadAllByResponseTime(userId, numberOfResults, startDate, endDate);

            UnitOfWork.End();

            return result;
        }

        public DataResult<IEnumerable<QuestionDto>> ReadAllByUserId(int userId)
        {
            UnitOfWork.Begin();

            var questionsResult = _questionWorkflow.ReadAllByUserId(userId);

            UnitOfWork.End();

            return questionsResult;
        }

        public DataResult<QuestionDto> Update(QuestionDto value)
        {
            UnitOfWork.Begin();

            var result = _questionWorkflow.Save(value);

            UnitOfWork.End();

            return result;
        }

        public DataResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public DataResult<QuestionAnalyticsDto> GetAnalytics(int questionId)
        {
            UnitOfWork.Begin();

            var result = _questionWorkflow.GetAnalytics(questionId);

            UnitOfWork.End();

            return result;
        }

        public DataResult<IEnumerable<QuestionDto>> Search(string term)
        {
            UnitOfWork.Begin();

            var result = _questionWorkflow.Search(term);

            UnitOfWork.End();

            return result;
        }
    }
}
