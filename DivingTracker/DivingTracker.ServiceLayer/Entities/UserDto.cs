using System;
using Humanizer;

namespace DivingTracker.ServiceLayer.Entities
{
    public class UserDto
    {
        public int? UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EmailAddress { get; set; }

        public string FullName => $"{FirstName} {Surname}";
        public string MemberFor => (DateTime.Now - CreatedDate).Humanize();

        public UserDto()
        {
        }
    }
}
