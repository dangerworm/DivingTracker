using System.Collections.Generic;
using System.Linq;
using DivingTracker.ServiceLayer;
using DivingTracker.ServiceLayer.Enums;

namespace DivingTracker.Web.Models
{
    public class BranchMembersModel
    {
        public BranchMembersModel(IEnumerable<UserQualification> qualifications, IEnumerable<User> users)
        {
            BranchQualifications = GetBranchQualifications(qualifications);
            Users = users.Select(x => new UserModel(x));
        }

        public Dictionary<int, QualificationModel> BranchQualifications { get; set; }

        public IEnumerable<QualificationModel> DivingQualifications => BranchQualifications.Values
            .Where(x => x.QualificationType == QualificationTypes.Diving);

        public IEnumerable<QualificationModel> InstructorQualifications => BranchQualifications.Values
            .Where(x => x.QualificationType == QualificationTypes.Instructor);

        public IEnumerable<UserModel> Users { get; set; }

        private static Dictionary<int, QualificationModel> GetBranchQualifications(
            IEnumerable<UserQualification> qualifications)
        {
            var branchQualifications = new Dictionary<int, QualificationModel>();

            foreach (var qualification in qualifications)
            {
                var key = qualification.QualificationId;

                if (branchQualifications.ContainsKey(key))
                    branchQualifications[key].Count += 1;
                else
                    branchQualifications.Add(key, new QualificationModel(qualification.Qualification));
            }

            return branchQualifications;
        }
    }
}