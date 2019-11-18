using System.Data;
using CommonCode.BusinessLayer;
using DivingTracker.ServiceLayer.DomainModels;
using Dapper;

namespace DivingTracker.ServiceLayer.Repositories
{
    public class UserRepository : EntityRepository<User>
    {
        public UserRepository(IUnitOfWork<IDbConnection, IDbTransaction> unitOfWork) 
            : base(unitOfWork)
        {
        }

        public override DataResult<User> Create(User value)
        {
            const string storedProcedureName = "dbo.USP_Users_Create";

            var parameters = new DynamicParameters();
            parameters.Add("@SystemLoginId", value.SystemLoginId, DbType.Int32);
            parameters.Add("@FirstName", value.FirstName, DbType.String);
            parameters.Add("@Surname", value.Surname, DbType.String);
            parameters.Add("@DateOfBirth", value.DateOfBirth, DbType.DateTime2);
            parameters.Add("@UserId", null, DbType.Int32, ParameterDirection.Output);

            return Read(storedProcedureName, parameters);
        }

        public DataResult<User> Read(int id)
        {
            const string storedProcedureName = "dbo.USP_Users_ReadById";

            var parameters = new DynamicParameters();
            parameters.Add("@Id", id, DbType.Int32);

            return Read(storedProcedureName, parameters);
        }

        public DataResult<User> ReadByEmailAddress(string emailAddress)
        {
            const string storedProcedureName = "dbo.USP_Users_ReadByEmailAddress";

            var parameters = new DynamicParameters();
            parameters.Add("@EmailAddress", emailAddress, DbType.String);

            return Read(storedProcedureName, parameters);
        }

        public DataResult<User> ReadBySystemLoginId(int id)
        {
            const string storedProcedureName = "dbo.USP_Users_ReadBySystemLoginId";

            var parameters = new DynamicParameters();
            parameters.Add("@SystemLoginId", id, DbType.Int32);

            return Read(storedProcedureName, parameters);
        }
    }
}
