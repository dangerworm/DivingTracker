using System.Collections.Generic;
using System.Data;
using CommonCode.BusinessLayer;
using DivingTracker.ServiceLayer.DomainModels;
using Dapper;

namespace DivingTracker.ServiceLayer.Repositories
{
    public class AnswerRepository : EntityRepository<Answer>
    {
        public AnswerRepository(IUnitOfWork<IDbConnection, IDbTransaction> unitOfWork) 
            : base(unitOfWork)
        {
        }

        public DataResult<Answer> Create(Answer value, int questionId)
        {
            const string storedProcedureName = "dbo.USP_Answers_Create";

            var parameters = new DynamicParameters();
            parameters.Add("@UserId", value.UserId, DbType.Int32);
            parameters.Add("@QuestionId", questionId, DbType.Int32);
            parameters.Add("@AnswerText", value.AnswerText?.Trim(), DbType.String);
            parameters.Add("@AnswerDescription", value.AnswerDescription?.Trim(), DbType.String);
            parameters.Add("@AnswerId", null, DbType.Int32, ParameterDirection.Output);

            return Read(storedProcedureName, parameters);
        }

        public DataResult<Answer> Read(int id)
        {
            const string storedProcedureName = "dbo.USP_Answers_ReadById";

            var parameters = new DynamicParameters();
            parameters.Add("@Id", id, DbType.Int32);

            return Read(storedProcedureName, parameters);
        }

        public DataResult<IEnumerable<Answer>> ReadAllByUserId(int userId)
        {
            const string storedProcedureName = "dbo.USP_Answers_ReadByUserId";

            var parameters = new DynamicParameters();
            parameters.Add("@UserId", userId, DbType.Int32);

            return ReadList(storedProcedureName, parameters);
        }

        public DataResult<IEnumerable<Answer>> ReadAllByQuestionId(int questionId)
        {
            const string storedProcedureName = "dbo.USP_Answers_ReadByQuestionId";

            var parameters = new DynamicParameters();
            parameters.Add("@QuestionId", questionId, DbType.Int32);

            return ReadList(storedProcedureName, parameters);
        }
    }
}
