using System.Linq;
using DivingTracker.ServiceLayer;
using DivingTracker.Web.Comparers;

namespace DivingTracker.Web.Models
{
    public class TrainingModuleModel
    {
        public ModuleModel Module { get; set; }

        public UserModel[] Users { get; set; }

        public UserCriterionModel[] UserCriteria { get; set; }

        public TrainingModuleModel(Module module, bool ignoreIncludeInSyllabus = false)
        {
            Module = new ModuleModel(module, ignoreIncludeInSyllabus);
            UserCriteria = module.ModuleSections.SelectMany(x => x.Criteria.SelectMany(y => y.UserCriterias))
                .Select(x => new UserCriterionModel(x)).ToArray();
            Users = UserCriteria.Select(x => x.User).Distinct(new UserModelComparer()).ToArray();
        }
    }
}