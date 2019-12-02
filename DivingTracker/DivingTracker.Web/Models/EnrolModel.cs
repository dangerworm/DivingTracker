using System.Collections.Generic;
using System.Linq;
using DivingTracker.ServiceLayer;

namespace DivingTracker.Web.Models
{
    public class EnrolModel
    {
        public EnrolModel()
        {
        }

        public EnrolModel(User user, IEnumerable<Qualification> qualifications)
        {
            User = new UserModel(user);
            EnrolPostModels = qualifications.Select(x => new EnrolPostModel(user.UserId, x)).ToArray();
        }

        public EnrolPostModel[] EnrolPostModels { get; set; }
        public UserModel User { get; set; }
    }
}