﻿using System;
using DivingTracker.ServiceLayer;
using DivingTracker.ServiceLayer.Enums;

namespace DivingTracker.Web.Models
{
    public class UserQualificationModel
    {
        public UserQualificationModel(UserQualification userQualification)
        {
            User = new UserModel(userQualification.User);
            Qualification = new QualificationModel(userQualification.Qualification);
            QualificationType = (QualificationTypes)userQualification.Qualification.QualificationTypeId;

            DateAwarded = userQualification.UpdatedDate;
        }

        public DateTime? DateAwarded { get; set; }
        public QualificationModel Qualification { get; set; }
        public QualificationTypes QualificationType { get; set; }
        public UserModel User { get; set; }
    }
}