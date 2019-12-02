using DivingTracker.ServiceLayer;

namespace DivingTracker.Web.Models
{
    public class InfoModel
    {
        public InfoModel(User user, Branch branch)
        {
            User = new UserModel(user);
            Branch = new BranchModel(branch);
        }

        public BranchModel Branch { get; set; }
        public UserModel User { get; set; }
    }
}