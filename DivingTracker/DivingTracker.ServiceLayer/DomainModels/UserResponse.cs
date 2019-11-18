using System;
using CommonCode.BusinessLayer.Interfaces;

namespace DivingTracker.ServiceLayer.DomainModels
{
    public class UserResponse : IIdentifiableByInteger
    {
        public int? Id => UserResponseId;
        public int? UserResponseId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
    }
}
