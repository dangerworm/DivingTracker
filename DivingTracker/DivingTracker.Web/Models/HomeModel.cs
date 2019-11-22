using System.Collections.Generic;
using DivingTracker.ServiceLayer;

namespace DivingTracker.Web.Models
{
    public class HomeModel
    {
        public UserModel User { get; set; }
        public Dictionary<int, QualificationModel> ClubQualifications { get; set; }

        public HomeModel()
        {
        }

        public HomeModel(User user, IEnumerable<UserQualification> qualifications)
        {
            User = new UserModel(user);
            ClubQualifications = GetClubQualifications(qualifications);
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