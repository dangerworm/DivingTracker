using System.Collections.Generic;
using DivingTracker.Web.Models;

namespace DivingTracker.Web.Comparers
{
    public class UserModelComparer : IEqualityComparer<UserModel>
    {
        public bool Equals(UserModel x, UserModel y)
        {
            return x?.UserId == y?.UserId;
        }

        public int GetHashCode(UserModel obj)
        {
            return obj.UserId.GetHashCode();
        }
    }
}