using System;
using DivingTracker.ServiceLayer;

namespace DivingTracker.Web.Models
{
    public class UserQualificationModel
    {
        public UserModel User { get; set; }
        public QualificationModel Qualification { get; set; }

        public DateTime? DateAwarded { get; set; }

        public UserQualificationModel(UserQualification userQualification)
        {
            User = new UserModel(userQualification.User);
            Qualification = new QualificationModel(userQualification.Qualification);

            DateAwarded = userQualification.UpdatedDate;
        }
    }
}