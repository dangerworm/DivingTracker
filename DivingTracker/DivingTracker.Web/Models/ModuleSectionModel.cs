using System.Collections.Generic;
using System.Linq;
using DivingTracker.ServiceLayer;

namespace DivingTracker.Web.Models
{
    public class ModuleSectionModel
    {
        public ModuleSectionModel()
        {
        }

        public ModuleSectionModel(ModuleSection moduleSection, bool ignoreIncludeInSyllabus = false)
        {
            ModuleSectionId = moduleSection.ModuleSectionId;
            Name = moduleSection.Name;
            Description = moduleSection.Description;
            Module = new ModuleModel(moduleSection.Module, ignoreIncludeInSyllabus);

            Criteria = moduleSection.Criteria
                .Where(x => ignoreIncludeInSyllabus || x.IncludeInSyllabus)
                .Select(x => new CriterionModel(x));
        }

        public IEnumerable<CriterionModel> Criteria { get; set; }

        public string Description { get; set; }

        public ModuleModel Module { get; set; }
        public int ModuleSectionId { get; set; }

        public string Name { get; set; }
    }
}