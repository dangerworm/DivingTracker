using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DivingTracker.ServiceLayer;
using DivingTracker.ServiceLayer.Enums;

namespace DivingTracker.Web.Models
{
    public class QualificationModel
    {
        public QualificationModel()
        {
        }

        public QualificationModel(Qualification qualification)
        {
            QualificationId = qualification.QualificationId;
            Name = qualification.Name;
            QualificationType = (QualificationTypes)qualification.QualificationTypeId;
            Description = qualification.Description;
            Agency = new AgencyModel(qualification.Agency);
            Modules = qualification.Modules.Select(x => new ModuleModel(x));
            Count = 1;

            switch (qualification.QualificationId)
            {
                case 1:
                    GlyphClass = "fas fa-user-tie";
                    break;
                case 2:
                    GlyphClass = "fas fa-ship";
                    break;
                case 3:
                    GlyphClass = "fas fa-table-tennis";
                    break;
                case 4:
                    GlyphClass = "fas fa-user-minus";
                    break;
                case 5:
                    GlyphClass = "fas fa-american-sign-language-interpreting";
                    break;
                case 6:
                    GlyphClass = "fas fa-user";
                    break;
                case 7:
                    GlyphClass = "fas fa-user-graduate";
                    break;
                case 8:
                    GlyphClass = "fas fa-arrow-alt-circle-up";
                    break;
                case 9:
                    GlyphClass = "fas fa-user-astronaut";
                    break;
                default:
                    GlyphClass = "fas fa-question-circle";
                    break;
            }
        }

        public AgencyModel Agency { get; set; }

        [DisplayName("Agency")]
        public string AgencyName => Agency.Name;

        public int Count { get; set; }

        public string Description { get; set; }

        public string GlyphClass { get; set; }

        public IEnumerable<ModuleModel> Modules { get; set; }

        public string Name { get; set; }
        
        [DisplayName ("Qualification ID")]
        public int QualificationId { get; set; }

        [DisplayName ("Qualification Type")]
        public QualificationTypes QualificationType { get; set; }
    }
}