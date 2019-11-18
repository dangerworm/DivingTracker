using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CommonCode.BusinessLayer;
using CommonCode.BusinessLayer.Helpers;
using DivingTracker.ServiceLayer.DomainModels;
using Dapper;

namespace DivingTracker.ServiceLayer.Repositories
{
    public class QuestionRepository : EntityRepository<Question>
    {
        public QuestionRepository(IUnitOfWork<IDbConnection, IDbTransaction> unitOfWork) 
            : base(unitOfWork, true)
        {
        }

        protected override Question Map(string storedProcedureName, DynamicParameters parameters)
        {
            using (var connection = UnitOfWork.GetConnection())
            {
                using (var reader = connection.QueryMultiple(storedProcedureName, parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    var question = reader.Read<Question>().FirstOrDefault();
                    if (question == null)
                    {
                        return null;
                    }

                    question.User = reader.Read<User>().FirstOrDefault();
                    question.Answers = reader.Read<Answer>();

                    return question;
                }
            }
        }

        protected override IEnumerable<Question> MapList(string storedProcedureName, DynamicParameters parameters)
        {
            using (var connection = UnitOfWork.GetConnection())
            {
                using (var reader = connection.QueryMultiple(storedProcedureName, parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    var questions = reader.Read<Question>().ToArray();
                    var users = reader.Read<User>().ToDictionary(x => x.UserId);
                    var answers = reader.Read<Answer>().ToDictionary(x => x.AnswerId);
                    var questionAnswers = reader.Read<QuestionAnswer>().ToLookup(x => x.QuestionId);

                    if (!questions.Any())
                    {
                        return Enumerable.Empty<Question>();
                    }

                    foreach (var question in questions)
                    {
                        question.User = users[question.UserId];
                        question.Answers = questionAnswers[question.QuestionId ?? -1]
                            .Select(x => answers[x.AnswerId])
                            .OrderBy(x => x.AnswerText, new SemiNumericComparer());
                    }

                    return questions;
                }
            }
        }

        public DataResult<Question> Save(Question value)
        {
            return !value.QuestionId.HasValue ? Create(value) : Update(value);
        }

        public override DataResult<Question> Create(Question value)
        {
            const string storedProcedureName = "dbo.USP_Questions_Create";

            var parameters = new DynamicParameters();
            parameters.Add("@UserId", value.UserId, DbType.Int32);
            parameters.Add("@QuestionText", value.QuestionText?.Trim(), DbType.String);
            parameters.Add("@QuestionDescription", value.QuestionDescription?.Trim(), DbType.String);
            parameters.Add("@QuestionId", null, DbType.Int32, ParameterDirection.Output);

            return Read(storedProcedureName, parameters);
        }

        public DataResult<Question> Read(int id)
        {
            const string storedProcedureName = "dbo.USP_Questions_ReadById";

            var parameters = new DynamicParameters();
            parameters.Add("@Id", id, DbType.Int32);

            return Read(storedProcedureName, parameters);
        }

        public DataResult<IEnumerable<Question>> ReadAll(int? numberOfResults, DateTime? startDate, DateTime? endDate)
        {
            const string storedProcedureName = "dbo.USP_Questions_ReadAll";

            var parameters = new DynamicParameters();
            parameters.Add("@NumberOfResults", numberOfResults, DbType.Int32);
            parameters.Add("@StartDate", startDate, DbType.DateTime2);
            parameters.Add("@EndDate", endDate, DbType.DateTime2);

            return ReadList(storedProcedureName, parameters);
        }

        public DataResult<IEnumerable<Question>> ReadAllByAnswerId(int answerId)
        {
            const string storedProcedureName = "dbo.USP_Questions_ReadByAnswerId";

            var parameters = new DynamicParameters();
            parameters.Add("@AnswerId", answerId, DbType.Int32);

            return ReadList(storedProcedureName, parameters);
        }

        public DataResult<IEnumerable<Question>> ReadAllByUserId(int userId)
        {
            const string storedProcedureName = "dbo.USP_Questions_ReadByUserId";

            var parameters = new DynamicParameters();
            parameters.Add("@UserId", userId, DbType.Int32);

            return ReadList(storedProcedureName, parameters);
        }

        public override DataResult<Question> Update(Question value)
        {
            const string storedProcedureName = "dbo.USP_Questions_Update";

            var parameters = new DynamicParameters();
            parameters.Add("@QuestionId", value.QuestionId, DbType.Int32);
            parameters.Add("@UserId", value.UserId, DbType.Int32);
            parameters.Add("@QuestionText", value.QuestionText?.Trim(), DbType.String);
            parameters.Add("@QuestionDescription", value.QuestionDescription?.Trim(), DbType.String);

            return Read(storedProcedureName, parameters);
        }

        public DataResult<IEnumerable<Question>> Search(string term)
        {
            const string storedProcedureName = "dbo.USP_Questions_Search";

            var parameters = new DynamicParameters();
            parameters.Add("@Term", term, DbType.String);

            return ReadList(storedProcedureName, parameters);
        }
    }
}
