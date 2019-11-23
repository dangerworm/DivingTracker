using System.Collections.Generic;
using System.Linq;
using DivingTracker.ServiceLayer;

namespace DivingTracker.Web.Models
{
    public class TrainingModel
    {
        public QualificationModel Qualification { get; set; }

        public TrainingModuleModel[] Modules { get; set; }

        public TrainingModel()
        {
        }

        public TrainingModel(Qualification qualification, IEnumerable<UserCriterion> userCriteria, bool ignoreIncludeInSyllabus = false)
        {
            Qualification = new QualificationModel(qualification);

            Modules = qualification.Modules.Select(x => new TrainingModuleModel(x, userCriteria, ignoreIncludeInSyllabus)).ToArray();
        }
    }
}