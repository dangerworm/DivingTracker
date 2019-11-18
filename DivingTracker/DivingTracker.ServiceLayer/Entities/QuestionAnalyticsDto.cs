using System.Collections.Generic;

namespace DivingTracker.ServiceLayer.Entities
{
    public class QuestionAnalyticsDto
    {
        public int QuestionId { get; set; }
        public IEnumerable<ResponseData> ResponseData { get; set; }
    }

    public class ResponseData
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
        public int ResponseCount { get; set; }
    }
}
