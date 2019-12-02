using DivingTracker.ServiceLayer;

namespace DivingTracker.Web.Models
{
    public class EnrolPostModel
    {
        public EnrolPostModel()
        {
        }

        public EnrolPostModel(int userId, Qualification qualification)
        {
            UserId = userId;
            Qualification = new QualificationModel(qualification);
            Selected = false;
        }

        public QualificationModel Qualification { get; set; }

        public bool Selected { get; set; }
        public int UserId { get; set; }
    }
}