using System;
using System.Data;
using CommonCode.BusinessLayer;
using DivingTracker.ServiceLayer.DomainModels;
using Dapper;

namespace DivingTracker.ServiceLayer.Repositories
{
    public class SystemLoginRepository : EntityRepository<SystemLogin>
    {
        public SystemLoginRepository(IUnitOfWork<IDbConnection, IDbTransaction> unitOfWork) 
            : base(unitOfWork)
        {
        }

        public override DataResult<SystemLogin> Create(SystemLogin value)
        {
            const string storedProcedureName = "dbo.USP_SystemLogins_Create";

            var parameters = new DynamicParameters();
            parameters.Add("@EmailAddress", value.EmailAddress, DbType.String);
            parameters.Add("@PasswordHash", value.PasswordHash, DbType.String);
            parameters.Add("@PasswordSalt", value.PasswordSalt, DbType.String);
            parameters.Add("@EmailConfirmationToken", value.EmailConfirmationToken, DbType.Guid);
            parameters.Add("@SystemLoginId", null, DbType.Int32, ParameterDirection.Output);

            return Read(storedProcedureName, parameters);
        }

        public DataResult<SystemLogin> ConfirmEmail(Guid emailConfirmationToken)
        {
            const string storedProcedureName = "dbo.USP_SystemLogins_ConfirmEmail";

            var parameters = new DynamicParameters();
            parameters.Add("@EmailConfirmationToken", emailConfirmationToken, DbType.Guid);

            return Read(storedProcedureName, parameters);
        }

        public DataResult<SystemLogin> ReadByEmailAddress(string emailAddress)
        {
            const string storedProcedureName = "dbo.USP_SystemLogins_ReadByEmailAddress";

            var parameters = new DynamicParameters();
            parameters.Add("@EmailAddress", emailAddress, DbType.String);

            return Read(storedProcedureName, parameters);
        }
    }
}
