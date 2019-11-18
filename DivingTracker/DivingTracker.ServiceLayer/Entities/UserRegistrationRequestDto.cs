using System;

namespace DivingTracker.ServiceLayer.Entities
{
    public class UserRegistrationRequestDto
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }

        public Guid ConfirmationToken { get; set; }
        public bool IsEmailConfirmed { get; set; }

    }
}
