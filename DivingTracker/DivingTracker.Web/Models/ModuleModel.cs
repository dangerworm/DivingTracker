using System.Collections.Generic;
using System.Linq;
using DivingTracker.ServiceLayer;
using DivingTracker.ServiceLayer.Enums;

namespace DivingTracker.Web.Models
{
    public class ModuleModel
    {
        public int ModuleId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public QualificationModel Qualification { get; set; }

        public IEnumerable<UserCriterionModel> UserCriteria { get; set; }

        public IEnumerable<ModuleSectionModel> ModuleSections { get; set; }

        public float Completeness
        {
            get
            {
                var totalComplete = ModuleSections.Sum(x => x.Criteria.Sum(y => y.UserCriteria.Count(z => z.CriterionStatus == CriterionStatuses.Complete)));
                var totalCriteria = ModuleSections.Sum(x => x.Criteria.Sum(y => y.UserCriteria.Count()));
                var completeness = totalComplete / (float)totalCriteria;

                return float.IsNaN(completeness) ? 0 : completeness;
            }
        }

        public ModuleModel()
        {
        }

        public ModuleModel(Module module, bool ignoreIncludeInSyllabus = false)
        {
            ModuleId = module.ModuleId;
            Name = module.Name;
            Description = module.Description;
            Qualification = new QualificationModel(module.Qualification);
            UserCriteria = module.ModuleSections.SelectMany(x => x.Criteria.SelectMany(y => y.UserCriterias)).Select(x => new UserCriterionModel(x)).ToArray();
            ModuleSections = module.ModuleSections?.Select(x => new ModuleSectionModel(x, ignoreIncludeInSyllabus));
        }
    }
}