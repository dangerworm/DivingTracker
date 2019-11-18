using System;

namespace DivingTracker.ServiceLayer.Entities
{
    public class SystemLoginDto
    {
        public int SystemLoginId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string EmailAddress { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public Guid EmailConfirmationToken { get; set; }
        public bool IsEmailConfirmed { get; set; }
    }
}
