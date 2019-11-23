using System.Collections.Generic;
using System.Linq;
using DivingTracker.ServiceLayer;
using DivingTracker.ServiceLayer.Enums;

namespace DivingTracker.Web.Models
{
    public class ClubMembersModel
    {
        public Dictionary<int, QualificationModel> ClubQualifications { get; set; }

        public IEnumerable<QualificationModel> DivingQualifications => ClubQualifications.Values
            .Where(x => x.QualificationType == QualificationTypes.Diving);

        public IEnumerable<QualificationModel> InstructorQualifications => ClubQualifications.Values
            .Where(x => x.QualificationType == QualificationTypes.Instructor);

        public IEnumerable<UserModel> Users { get; set; }

        public ClubMembersModel(IEnumerable<UserQualification> qualifications, IEnumerable<User> users)
        {
            ClubQualifications = GetClubQualifications(qualifications);
            Users = users.Select(x => new UserModel(x));
        }

        private static Dictionary<int, QualificationModel> GetClubQualifications(IEnumerable<UserQualification> qualifications)
        {
            var clubQualifications = new Dictionary<int, QualificationModel>();

            foreach (var qualification in qualifications)
            {
                if (!qualification.QualificationId.HasValue)
                    continue;

                var key = qualification.QualificationId.Value;

                if (clubQualifications.ContainsKey(key))
                {
                    clubQualifications[key].Count += 1;
                }
                else
                {
                    clubQualifications.Add(key, new QualificationModel(qualification.Qualification));
                }
            }

            return clubQualifications;
        }
    }
}