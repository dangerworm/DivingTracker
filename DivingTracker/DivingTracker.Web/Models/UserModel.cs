using System;

namespace DivingTracker.Web.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
    }
}