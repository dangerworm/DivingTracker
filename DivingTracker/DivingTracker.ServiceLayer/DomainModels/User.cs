using System;
using CommonCode.BusinessLayer.Interfaces;

namespace DivingTracker.ServiceLayer.DomainModels
{
    public class User : IIdentifiableByInteger
    {
        public int? Id => UserId;
        public int? UserId { get; set; }
        public int SystemLoginId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EmailAddress { get; set; }

        public User()
        {
        }
    }
}
