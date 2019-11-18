using System;

namespace DivingTracker.ServiceLayer.Entities
{
    public class UserResponseDto
    {
        public int? UserResponseId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
    }
}
