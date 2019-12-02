using System;
using System.Data;
using CommonCode.BusinessLayer;
using CommonCode.BusinessLayer.Helpers;
using CommonCode.BusinessLayer.Services;
using DivingTracker.ServiceLayer.DataTransferObjects;
using DivingTracker.ServiceLayer.Interfaces;
using DivingTracker.ServiceLayer.Workflows;

namespace DivingTracker.ServiceLayer.Services
{
    public class AuthenticationService : ServiceBase<IDbConnection, IDbTransaction>, IAuthenticationService
    {
        private readonly AuthenticationWorkflow _authenticationWorkflow;

        public AuthenticationService(IUnitOfWork<IDbConnection, IDbTransaction> unitOfWork,
            AuthenticationWorkflow authenticationWorkflow)
            : base(unitOfWork)
        {
            Verify.NotNull(authenticationWorkflow, nameof(authenticationWorkflow));

            _authenticationWorkflow = authenticationWorkflow;
        }

        public DataResult<User> Register(UserRegistrationRequestDto registrationRequest)
        {
            UnitOfWork.Begin();

            var result = _authenticationWorkflow.Register(registrationRequest);

            UnitOfWork.End();

            return result;
        }

        public DataResult<User> ConfirmEmail(Guid emailConfirmationToken)
        {
            UnitOfWork.Begin();

            var result = _authenticationWorkflow.Confirm(emailConfirmationToken);

            UnitOfWork.End();

            return result;
        }

        public DataResult<User> Login(string emailAddress, string password)
        {
            UnitOfWork.Begin();

            var result = _authenticationWorkflow.Login(emailAddress, password);

            UnitOfWork.End();

            return result;
        }
    }
}