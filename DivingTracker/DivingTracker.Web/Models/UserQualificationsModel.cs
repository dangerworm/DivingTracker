using System.Collections.Generic;
using System.Linq;
using DivingTracker.ServiceLayer;

namespace DivingTracker.Web.Models
{
    public class UserQualificationsModel
    {
        public UserModel User { get; set; }

        public IEnumerable<QualificationModel> QualificationsCompleted { get; set; }

        public IEnumerable<QualificationModel> QualificationsInProgress { get; set; }

        public UserQualificationsModel(User user, IEnumerable<Qualification> qualificationsCompleted, 
            IEnumerable<Qualification> qualificationsInProgress)
        {
            User = new UserModel(user);
            QualificationsCompleted = qualificationsCompleted.Select(x => new QualificationModel(x));
            QualificationsInProgress = qualificationsInProgress.Select(x => new QualificationModel(x));
        }
    }
}
