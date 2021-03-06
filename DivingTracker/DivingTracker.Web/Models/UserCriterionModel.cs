﻿using System;
using DivingTracker.ServiceLayer;
using DivingTracker.ServiceLayer.Enums;

namespace DivingTracker.Web.Models
{
    public class UserCriterionModel
    {
        public UserCriterionModel()
        {
        }

        public UserCriterionModel(UserCriterion userCriterion)
        {
            CriterionId = userCriterion.CriterionId;
            UpdatedDate = userCriterion.UpdatedDate;

            Criterion = new CriterionModel(userCriterion.Criterion);
            CriterionStatus = (CriterionStatuses)userCriterion.CriterionStatus.CriterionStatusId;
            User = new UserModel(userCriterion.User);

            if (AwardedByUser == null)
                return;

            AwardedByUser = new UserModel(userCriterion.AwardedByUser);
        }

        public UserModel AwardedByUser { get; set; }

        public CriterionModel Criterion { get; set; }
        public int CriterionId { get; set; }
        public CriterionStatuses CriterionStatus { get; set; }

        public string CriterionStatusGlyph => GetCriterionStatusGlyph();
        public DateTime? UpdatedDate { get; set; }
        public UserModel User { get; set; }

        private string GetCriterionStatusGlyph()
        {
            switch (CriterionStatus)
            {
                case CriterionStatuses.Unknown:
                    return "fas fa-question";
                case CriterionStatuses.NotStarted:
                    return "fas fa-battery-empty";
                case CriterionStatuses.NeedsConsolidation:
                    return "fas fa-battery-half";
                case CriterionStatuses.Complete:
                    return "fas fa-battery-full";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}