using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DivingTracker.ServiceLayer;
using Newtonsoft.Json;

namespace DivingTracker.Web.Models
{
    public class UserModel
    {
        [DisplayName("User ID")]
        public int UserId { get; set; }

        [DisplayName("Created Date")]
        public DateTime? CreatedDate { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        public string Surname { get; set; }

        [DisplayName("Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? DateOfBirth { get; set; }

        [DisplayName("Email Address")]
        public string EmailAddress => SystemLogin.EmailAddress;

        public string Role => SystemRole.Description;

        public SystemLogin SystemLogin { get; set; }
        public SystemRole SystemRole { get; set; }
    }
}