using System.Collections.Generic;
using System.Data;
using CommonCode.BusinessLayer;
using DivingTracker.ServiceLayer.DomainModels;
using Dapper;
using DivingTracker.ServiceLayer.Interfaces;

namespace DivingTracker.ServiceLayer.Repositories
{
    public class UserResponseRepository : EntityRepository<UserResponse>
    {
        public UserResponseRepository(IUnitOfWork<IDbConnection, IDbTransaction> unitOfWork)
            : base(unitOfWork)
        {
        }

        public DataResult<UserResponse> ReadByUserAndQuestionId(int userId, int questionId)
        {
            const string storedProcedureName = "dbo.USP_UserResponses_ReadByUserAndQuestionId";

            var parameters = new DynamicParameters();
            parameters.Add("@UserId", userId, DbType.Int32);
            parameters.Add("@QuestionId", questionId, DbType.Int32);

            return Read(storedProcedureName, parameters);
        }

        public DataResult<IEnumerable<UserResponse>> ReadAllByUserId(int userId)
        {
            const string storedProcedureName = "dbo.USP_UserResponses_ReadByUserId";

            var parameters = new DynamicParameters();
            parameters.Add("@UserId", userId, DbType.Int32);

            return ReadList(storedProcedureName, parameters);
        }

        public DataResult SubmitAnswer(int userId, int questionId, int answerId)
        {
            const string storedProcedureName = "dbo.USP_UserResponses_SubmitAnswer";

            var parameters = new DynamicParameters();
            parameters.Add("@UserId", userId, DbType.Int32);
            parameters.Add("@QuestionId", questionId, DbType.Int32);
            parameters.Add("@AnswerId", answerId, DbType.Int32);

            return ExecuteStoredProcedure(storedProcedureName, parameters);
        }
    }
}
