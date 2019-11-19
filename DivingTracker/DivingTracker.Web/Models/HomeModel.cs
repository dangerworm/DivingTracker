using System.Collections.Generic;
using DivingTracker.ServiceLayer;

namespace DivingTracker.Web.Models
{
    public class HomeModel
    {
        public User User { get; set; }
        public Dictionary<string, int> ClubQualifications { get; set; }
    }
}