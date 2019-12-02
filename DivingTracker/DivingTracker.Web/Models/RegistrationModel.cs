using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DivingTracker.Web.Models
{
    public class RegistrationModel
    {
        public Guid ConfirmationToken => Guid.NewGuid();

        [DataType(DataType.DateTime, ErrorMessage =
            "The date of birth is not a valid date. Please use dd/mm/yyyy format.")]
        [DisplayName("Date of Birth")]
        [Required]
        public DateTime DateOfBirth { get; set; }

        [DisplayName("Email Address")]
        [EmailAddress]
        [Required]
        //[RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "The email address is not valid")]
        public string EmailAddress { get; set; }

        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [DisplayName("Password")]
        [Required]
        [StringLength(256, MinimumLength = 8, ErrorMessage = "Your password must be at least 8 characters")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "The passwords must match")]
        [DisplayName("Confirm Password")]
        [Required]
        public string PasswordConfirmation { get; set; }

        [DisplayName("Surname")]
        [Required]
        public string Surname { get; set; }
    }
}