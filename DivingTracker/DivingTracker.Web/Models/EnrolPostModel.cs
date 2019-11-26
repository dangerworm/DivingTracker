using DivingTracker.ServiceLayer;

namespace DivingTracker.Web.Models
{
    public class EnrolPostModel
    {
        public int UserId { get; set; }

        public QualificationModel Qualification { get; set; }

        public bool Selected { get; set; }

        public EnrolPostModel()
        {
        }

        public EnrolPostModel(int userId, Qualification qualification)
        {
            UserId = userId;
            Qualification = new QualificationModel(qualification);
            Selected = false;
        }
    }
}