using System.Data;
using System.Data.Common;
using CommonCode.BusinessLayer;
using CommonCode.BusinessLayer.Interfaces;
using CommonCode.BusinessLayer.Repositories;
using Dapper;

namespace DivingTracker.ServiceLayer.Repositories
{
    public abstract class EntityRepository<T> : SqlRepositoryBase<T>
        where T : IIdentifiableByInteger
    {
        protected EntityRepository(IUnitOfWork<IDbConnection, IDbTransaction> unitOfWork, bool hasCustomReader = false)
            : base (unitOfWork, hasCustomReader)
        {
        }

        protected DataResult<T> Save(string storedProcedureName, DynamicParameters parameters)
        {
            DataResultType resultType;
            string commandType;
            string commandTypePastTense;
            string friendlyMessage;
            string internalMessage;
            InitialiseInformativeVariables(storedProcedureName, out commandType, out commandTypePastTense, 
                out resultType, out friendlyMessage, out internalMessage);

            DbException dbException = null;
            var value = default(T);
            var rowCount = 0;

            try
            {
                if (parameters == null)
                {
                    parameters = new DynamicParameters();
                }

                parameters.Add("RowCount", null, DbType.Int32, ParameterDirection.ReturnValue);

                value = UnitOfWork.GetConnection()
                    .QueryFirstOrDefault<T>(storedProcedureName, parameters,
                        commandType: CommandType.StoredProcedure);

                rowCount = parameters.Get<int>("RowCount");

                if (rowCount > 0)
                {
                    if (value.Id.HasValue)
                    {
                        resultType = DataResultType.Success;
                        friendlyMessage = "Success";
                        internalMessage = $"Record(s) {commandTypePastTense} successfully.";
                    }
                    else
                    {
                        resultType = DataResultType.UnknownRecord;
                        friendlyMessage = "The database did not give a valid response.";
                        internalMessage = "Unable to retrieve the record ID.";
                    }
                }
                else
                {
                    resultType = DataResultType.NoRecordsAffected;
                    friendlyMessage = "Sorry, an unexpected error has occurred.";
                    internalMessage = $"Unable to {commandType} record. No records affected.";
                }
            }
            catch (DbException exception)
            {
                resultType = DataResultType.UnknownError;
                internalMessage = $"Unable to {commandType} record. An exception occurred with the database.";
                dbException = exception;
            }

            return CreateDataResult(storedProcedureName, rowCount, value, resultType, friendlyMessage, internalMessage, value.Id, dbException);
        }
    }
}
