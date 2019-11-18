using System;
using CommonCode.BusinessLayer.Interfaces;

namespace DivingTracker.ServiceLayer.DomainModels
{
    public class QuestionAnalytics : IIdentifiableByInteger
    {
        public int? Id => Convert.ToInt32($"{QuestionId}{AnswerId}");
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
        public int ResponseCount { get; set; }
    }
}
