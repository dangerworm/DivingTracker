using System;

namespace DivingTracker.ServiceLayer.Entities
{
    public class QuestionEditDto
    {
        public UserDto User { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
    }
}
