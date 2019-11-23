﻿using System.Collections.Generic;
using System.Linq;
using DivingTracker.ServiceLayer;

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

        public ModuleModel()
        {
        }

        public ModuleModel(Module module, IEnumerable<UserCriterion> userCriteria, bool ignoreIncludeInSyllabus = false)
        {
            ModuleId = module.ModuleId;
            Name = module.Name;
            Description = module.Description;
            Qualification = new QualificationModel(module.Qualification);
            UserCriteria = userCriteria?.Select(x => new UserCriterionModel(x)).ToArray();
            ModuleSections = module.ModuleSections?.Select(x => new ModuleSectionModel(x, ignoreIncludeInSyllabus));
        }
    }
}