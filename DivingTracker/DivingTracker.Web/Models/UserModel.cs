using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DivingTracker.ServiceLayer;

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

        [DisplayName("Name")]
        public string Name => $"{FirstName} {Surname}";

        [DisplayName("Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:D}")]
        public DateTime? DateOfBirth { get; set; }

        [DisplayName("Email Address")]
        public string EmailAddress => SystemLogin.EmailAddress;

        [DisplayName("Access Level")]
        public string Role => SystemRole.Description;

        public SystemLogin SystemLogin { get; set; }
        public SystemRole SystemRole { get; set; }

        public IEnumerable<QualificationModel> Qualifications { get; set; }
        public IEnumerable<ModuleModel> Modules { get; set; }

        public UserModel()
        {
        }

        public UserModel(User user)
        {
            UserId = user.UserId;
            CreatedDate = user.CreatedDate;
            FirstName = user.FirstName;
            Surname = user.Surname;
            DateOfBirth = user.DateOfBirth;
            SystemLogin = user.SystemLogin;
            SystemRole = user.SystemRole;

            Qualifications = user.UserQualifications.Select(x => new QualificationModel(x.Qualification));
            Modules = user.UserCriterias.Select(x => x.Criterion.ModuleSection.Module).Select(x => new ModuleModel(x));
        }
    }
}