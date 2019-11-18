using System.Collections.Generic;
using DivingTracker.ServiceLayer.Entities;

namespace DivingTracker.Web.Models
{
    public class DashboardModel
    {
        public UserDto User { get; set; }
        public IEnumerable<QuestionDto> TopQuestions { get; set; }
        public IEnumerable<QuestionDto> Questions { get; set; }
    } 
}