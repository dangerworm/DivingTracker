using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DivingTracker.ServiceLayer.Entities;

namespace DivingTracker.Web.Models
{
    public class ProfileModel
    {
        public UserDto User { get; set; }
        public IEnumerable<QuestionDto> Questions { get; set; }
        public IEnumerable<AnswerDto> Answers { get; set; }
        public IEnumerable<UserResponseDto> Responses { get; set; }
    }
}