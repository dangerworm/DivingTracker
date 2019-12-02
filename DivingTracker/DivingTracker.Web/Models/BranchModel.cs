using System.ComponentModel;
using DivingTracker.ServiceLayer;

namespace DivingTracker.Web.Models
{
    public class BranchModel
    {
        public BranchModel(Branch branch)
        {
            BranchAddress = new AddressModel(branch.BranchAddress);
            PoolAddress = new AddressModel(branch.PoolAddress);
            Agency = new AgencyModel(branch.Agency);
            President = new UserModel(branch.BranchChair);
            DivingOfficer = new UserModel(branch.BranchDivingOfficer);
            Secretary = new UserModel(branch.BranchSecretary);
            Treasurer = new UserModel(branch.BranchTreasurer);

            ContactEmail = branch.ContactEmail;
            ContactLandLine = branch.ContactLandLine;
            ContactMobile = branch.ContactMobile;
        }

        public AgencyModel Agency { get; set; }

        [DisplayName("Branch Address")]
        public AddressModel BranchAddress { get; set; }

        [DisplayName("Contact Email")]
        public string ContactEmail { get; set; }

        [DisplayName("Phone (Landline)")]
        public string ContactLandLine { get; set; }

        [DisplayName("Phone (Mobile)")]
        public string ContactMobile { get; set; }

        [DisplayName("Diving Officer")]
        public UserModel DivingOfficer { get; set; }

        [DisplayName("Pool Address")]
        public AddressModel PoolAddress { get; set; }

        public UserModel President { get; set; }

        public UserModel Secretary { get; set; }

        public UserModel Treasurer { get; set; }
    }
}