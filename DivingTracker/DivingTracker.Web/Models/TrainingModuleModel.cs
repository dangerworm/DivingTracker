using System.Collections.Generic;
using System.Linq;
using DivingTracker.ServiceLayer;

namespace DivingTracker.Web.Models
{
    public class TrainingModuleModel
    {
        public ModuleModel Module { get; set; }

        public UserModel[] Users { get; set; }

        public UserCriterionModel[] UserCriteria { get; set; }

        public TrainingModuleModel(Module module, IEnumerable<UserCriterion> userCriteria, bool ignoreIncludeInSyllabus = false)
        {
            Module = new ModuleModel(module, userCriteria, ignoreIncludeInSyllabus);
            UserCriteria = userCriteria.Select(x => new UserCriterionModel(x)).ToArray();
            Users = userCriteria.Select(x => new UserModel(x.User)).Distinct().ToArray();
        }
    }
}