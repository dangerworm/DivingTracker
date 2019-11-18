using System;
using System.Data.SqlClient;
using CommonCode.BusinessLayer;
using CommonCode.BusinessLayer.Helpers;
using CommonCode.BusinessLayer.Services;
using DivingTracker.ServiceLayer.Entities;
using DivingTracker.ServiceLayer.Helpers;
using DivingTracker.ServiceLayer.Interfaces;
using DivingTracker.ServiceLayer.Workflows;

namespace DivingTracker.ServiceLayer.Services
{
    public class AuthenticationService : ServiceBase<SqlConnection, SqlTransaction>, IAuthenticationService
    {
        private readonly AuthenticationWorkflow _authenticationWorkflow;

        public AuthenticationService(IUnitOfWork<SqlConnection, SqlTransaction> unitOfWork, AuthenticationWorkflow authenticationWorkflow)
            :base(unitOfWork)
        {
            Verify.NotNull(authenticationWorkflow, nameof(authenticationWorkflow));

            _authenticationWorkflow = authenticationWorkflow;
        }

        public DataResult<UserDto> Register(UserRegistrationRequestDto registrationRequest)
        {
            UnitOfWork.Begin();

            var result = _authenticationWorkflow.Register(registrationRequest);

            UnitOfWork.End();

            return result;
        }

        public DataResult<UserDto> ConfirmEmail(Guid emailConfirmationToken)
        {
            UnitOfWork.Begin();

            var result = _authenticationWorkflow.Confirm(emailConfirmationToken);

            UnitOfWork.End();

            return result;
        }

        public DataResult<UserDto> Login(string emailAddress, string password)
        {
            UnitOfWork.Begin();

            var result = _authenticationWorkflow.Login(emailAddress, password);

            UnitOfWork.End();

            return result;
        }
    }
}
