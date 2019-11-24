using DivingTracker.ServiceLayer;

namespace DivingTracker.Web.Models
{
    public class InfoModel
    {
        public UserModel User { get; set; }

        public BranchModel Branch { get; set; }

        public InfoModel(User user, Branch branch)
        {
            User = new UserModel(user);
            Branch = new BranchModel(branch);
        }
    }
}