using System;

namespace DivingTracker.ServiceLayer.DataTransferObjects
{
    public class UserRegistrationRequestDto
    {
        public Guid ConfirmationToken { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
        public string Surname { get; set; }
    }
}