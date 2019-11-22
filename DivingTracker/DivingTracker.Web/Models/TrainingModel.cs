using System.Collections.Generic;
using System.Linq;
using DivingTracker.ServiceLayer;

namespace DivingTracker.Web.Models
{
    public class TrainingModel
    {
        public Qualification Qualification { get; set; }

        public UserCriterionModel[] UserCriteria { get; set; }

        public ModuleSectionModel[] ModuleSections { get; set; }

        public ModuleModel[] Modules { get; set; }

        public UserModel[] Users { get; set; }

        public Dictionary<int, ModuleModel> ModuleSectionModuleDictionary { get; set; }

        public TrainingModel()
        {
        }

        public TrainingModel(IEnumerable<User> users, IEnumerable<UserCriterion> userCriteria, 
            IEnumerable<ModuleSection> moduleSections, IEnumerable<Module> modules,
            bool ignoreIncludeInSyllabus = false)
        {
            Users = users.Select(x => new UserModel(x)).ToArray();
            UserCriteria = userCriteria.Select(x => new UserCriterionModel(x)).ToArray();
            ModuleSections = moduleSections.Select(x => new ModuleSectionModel(x, ignoreIncludeInSyllabus)).ToArray();
            Modules = modules.Select(x => new ModuleModel(x, ignoreIncludeInSyllabus)).ToArray();

            ModuleSectionModuleDictionary = moduleSections.ToDictionary(x => x.ModuleSectionId, y => new ModuleModel(y.Module, ignoreIncludeInSyllabus));
        }
    }
}