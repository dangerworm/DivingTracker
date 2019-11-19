using System;
using CommonCode.BusinessLayer;
using DivingTracker.ServiceLayer.DataTransferObjects;

namespace DivingTracker.ServiceLayer.Interfaces
{
    public interface IAuthenticationService
    {
        DataResult<User> Register(UserRegistrationRequestDto registrationRequest);
        DataResult<User> ConfirmEmail(Guid emailConfirmationToken);
        DataResult<User> Login(string emailAddress, string password);
    }
}
