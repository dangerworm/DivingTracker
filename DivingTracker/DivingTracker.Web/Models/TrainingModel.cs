using System.Linq;
using DivingTracker.ServiceLayer;

namespace DivingTracker.Web.Models
{
    public class TrainingModel
    {
        public TrainingModel()
        {
        }

        public TrainingModel(Qualification qualification, bool ignoreIncludeInSyllabus = false)
        {
            Qualification = new QualificationModel(qualification);

            Modules = qualification.Modules.Select(x => new TrainingModuleModel(x, ignoreIncludeInSyllabus)).ToArray();
        }

        public TrainingModuleModel[] Modules { get; set; }
        public QualificationModel Qualification { get; set; }
    }
}