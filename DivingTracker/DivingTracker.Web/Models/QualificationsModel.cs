using System.Collections.Generic;
using System.Linq;
using DivingTracker.ServiceLayer;

namespace DivingTracker.Web.Models
{
    public class QualificationsModel
    {
        public IEnumerable<QualificationModel> Qualifications { get; set; }

        public QualificationsModel(IEnumerable<Qualification> qualifications)
        {
            Qualifications = qualifications.Select(x => new QualificationModel(x));
        }
    }
}