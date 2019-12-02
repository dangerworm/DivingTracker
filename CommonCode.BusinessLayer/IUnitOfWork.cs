using System.Collections.Generic;

namespace CommonCode.BusinessLayer
{
    public interface IUnitOfWork<TConnection, TTransaction>
    {
        // DataResults
        void AddDataResult(DataResult result);

        IUnitOfWork<TConnection, TTransaction> Begin();
        void BeginTransaction();
        void Commit();

        void Dispose();
        void End();
        void EndTransaction();

        IReadOnlyCollection<DataResult> GetAllDataResults();

        // Connection handling
        TConnection GetConnection();

        DataResult GetLastDataResult();

        // Transaction handling
        TTransaction GetTransaction();

        bool HasConnectionOrSession();
        bool IsSuccess();
        void Rollback();
    }
}