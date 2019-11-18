using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CommonCode.BusinessLayer;
using CommonCode.BusinessLayer.Helpers;
using CommonCode.BusinessLayer.Services;
using DivingTracker.ServiceLayer.Entities;
using DivingTracker.ServiceLayer.Interfaces;
using DivingTracker.ServiceLayer.Workflows;

namespace DivingTracker.ServiceLayer.Services
{
    public class AnswerService : ServiceBase<SqlConnection, SqlTransaction>, IAnswerService
    {
        private readonly AnswerWorkflow _answerWorkflow;

        public AnswerService(IUnitOfWork<SqlConnection, SqlTransaction> unitOfWork, AnswerWorkflow answerWorkflow)
            : base(unitOfWork)
        {
            Verify.NotNull(answerWorkflow, nameof(answerWorkflow));

            _answerWorkflow = answerWorkflow;
        }

        public DataResult<AnswerDto> Create(AnswerDto value)
        {
            UnitOfWork.Begin();

            var result = _answerWorkflow.Create(value);

            UnitOfWork.End();

            return result;
        }

        public DataResult<AnswerDto> Read(int id)
        {
            UnitOfWork.Begin();

            var result = _answerWorkflow.Read(id);

            UnitOfWork.End();

            return result;
        }

        public DataResult<IEnumerable<AnswerDto>> ReadAllByUserId(int userId)
        {
            UnitOfWork.Begin();

            var result = _answerWorkflow.ReadAllByUserId(userId);

            UnitOfWork.End();

            return result;
        }

        public DataResult Delete(int id)
        {
            throw new NotImplementedException();
        }


        public DataResult SubmitAnswer(int userId, int questionId, int answerId)
        {
            UnitOfWork.Begin();

            var result = _answerWorkflow.SubmitAnswer(userId, questionId, answerId);

            UnitOfWork.End();

            return result;
        }
    }
}
