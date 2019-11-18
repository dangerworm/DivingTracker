using System;
using CommonCode.BusinessLayer;
using DivingTracker.ServiceLayer.Entities;

namespace DivingTracker.ServiceLayer.Interfaces
{
    public interface IAuthenticationService
    {
        DataResult<UserDto> Register(UserRegistrationRequestDto registrationRequest);
        DataResult<UserDto> ConfirmEmail(Guid emailConfirmationToken);
        DataResult<UserDto> Login(string emailAddress, string password);
    }
}
