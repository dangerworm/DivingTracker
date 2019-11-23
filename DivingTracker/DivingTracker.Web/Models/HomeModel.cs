using System.Collections.Generic;
using DivingTracker.ServiceLayer;

namespace DivingTracker.Web.Models
{
    public class HomeModel
    {
        public UserModel User { get; set; }

        public HomeModel()
        {
        }

        public HomeModel(User user)
        {
            User = new UserModel(user);
        }
    }
}