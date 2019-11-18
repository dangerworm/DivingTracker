using System.Collections.Generic;
using System.Data;
using CommonCode.BusinessLayer;
using CommonCode.BusinessLayer.Repositories;
using DivingTracker.ServiceLayer.DomainModels;
using Dapper;
using DivingTracker.ServiceLayer.Interfaces;

namespace DivingTracker.ServiceLayer.Repositories
{
    public class QuestionAnalyticsRepository : SqlRepositoryBase<QuestionAnalytics>
    {
        public QuestionAnalyticsRepository(IUnitOfWork<IDbConnection, IDbTransaction> unitOfWork) 
            : base(unitOfWork, false)
        {
        }

        public DataResult<IEnumerable<QuestionAnalytics>> ReadAllByQuestionId(int questionId)
        {
            const string storedProcedureName = "dbo.USP_QuestionAnalytics_ReadByQuestionId";

            var parameters = new DynamicParameters();
            parameters.Add("@QuestionId", questionId, DbType.Int32);

            return ReadList(storedProcedureName, parameters);
        }
    }
}
