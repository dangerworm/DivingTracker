using System.Collections.Generic;
using System.Linq;
using DivingTracker.ServiceLayer;
using Microsoft.ApplicationInsights;

namespace DivingTracker.Web.Models
{
    public class CriterionModel
    {
        public int CriterionId { get; set; }

        public string Description { get; set; }

        public string Details { get; set; }

        public bool IncludeInSyllabus { get; set; }

        public IEnumerable<UserCriterionModel> UserCriteria { get; set; }

        public CriterionModel()
        {
        }

        public CriterionModel(Criterion criterion)
        {
            CriterionId = criterion.CriterionId;
            Description = criterion.Description;
            Details = criterion.Details;
            IncludeInSyllabus = criterion.IncludeInSyllabus;
            UserCriteria = criterion.UserCriterias.Select(x => new UserCriterionModel(x));
        }
    }
}