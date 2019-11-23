using System.Collections.Generic;
using System.Linq;
using DivingTracker.ServiceLayer;

namespace DivingTracker.Web.Models
{
    public class ModuleSectionModel
    {
        public int ModuleSectionId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ModuleModel Module { get; set; }

        public IEnumerable<CriterionModel> Criteria { get; set; }

        public ModuleSectionModel()
        {
        }

        public ModuleSectionModel(ModuleSection moduleSection, bool ignoreIncludeInSyllabus = false)
        {
            ModuleSectionId = moduleSection.ModuleSectionId;
            Name = moduleSection.Name;
            Description = moduleSection.Description;
            Module = new ModuleModel(moduleSection.Module, null, ignoreIncludeInSyllabus);

            Criteria = moduleSection.Criteria
                .Where(x => ignoreIncludeInSyllabus || x.IncludeInSyllabus)
                .Select(x => new CriterionModel(x));
        }
    }
}