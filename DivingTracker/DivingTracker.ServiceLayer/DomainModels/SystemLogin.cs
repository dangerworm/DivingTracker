using System;
using CommonCode.BusinessLayer.Interfaces;

namespace DivingTracker.ServiceLayer.DomainModels
{
    public class SystemLogin : IIdentifiableByInteger
    {
        public int? Id => SystemLoginId;
        public int? SystemLoginId { get; set; }
        public int? UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string EmailAddress { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public Guid EmailConfirmationToken { get; set; }
        public bool IsEmailConfirmed { get; set; }
    }
}
