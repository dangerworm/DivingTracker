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
        public UserModel()
        {
        }

        public UserModel(User user)
        {
            UserId = user.UserId;
            Branch = user.Branch;
            CreatedDate = user.CreatedDate;
            FirstName = user.FirstName;
            Surname = user.Surname;
            DateOfBirth = user.DateOfBirth;
            SystemLogin = user.SystemLogin;
            SystemRole = user.SystemRole;

            Qualifications = user.UserQualifications.Select(x => new QualificationModel(x.Qualification));
            Modules = user.UserCriterias.Select(x => x.Criterion.ModuleSection.Module).Select(x => new ModuleModel(x));
        }


        [DisplayName("Created Date")]
        public DateTime? CreatedDate { get; set; }

        [DisplayName("Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? DateOfBirth { get; set; }

        [DisplayName("Email Address")]
        public string EmailAddress => SystemLogin.EmailAddress;

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        public IEnumerable<ModuleModel> Modules { get; set; }

        [DisplayName("Name")]
        public string Name => $"{FirstName} {Surname}";

        public IEnumerable<QualificationModel> Qualifications { get; set; }

        [DisplayName("Access Level")]
        public string Role => SystemRole.Description;

        public string Surname { get; set; }

        public Branch Branch { get; set; }
        public SystemLogin SystemLogin { get; set; }
        public SystemRole SystemRole { get; set; }

        [DisplayName("User ID")]
        public int UserId { get; set; }
    }
}