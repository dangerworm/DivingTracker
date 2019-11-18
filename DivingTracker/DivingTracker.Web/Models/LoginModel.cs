using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DivingTracker.Web.Models
{
    public class LoginModel
    {
        [DisplayName("Email Address")]
        [EmailAddress]
        [Required]
        //[RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "This is not an email")]
        public string EmailAddress { get; set; }

        [DisplayName("Password")]
        [Required]
        [StringLength(256, MinimumLength = 8, ErrorMessage = "Your password must be at least 8 characters")]
        public string Password { get; set; }
    }
}