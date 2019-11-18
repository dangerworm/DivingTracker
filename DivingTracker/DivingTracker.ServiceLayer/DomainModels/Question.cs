using System;
using System.Collections.Generic;
using CommonCode.BusinessLayer.Interfaces;

namespace DivingTracker.ServiceLayer.DomainModels
{
    public class Question : IIdentifiableByInteger
    {
        public int? Id => QuestionId;
        public int? QuestionId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
        public string QuestionText { get; set; }
        public string QuestionDescription { get; set; }
        public int AnswerCount { get; set; }
        public int ResponseCount { get; set; }
        public DateTime LastResponseTime { get; set; }

        public User User { get; set; }
        public IEnumerable<Answer> Answers { get; set; } 

        public Question()
        {
        }

        public Question(DateTime createdDate, int userId, string questionText, string questionDescription)
        {
            CreatedDate = createdDate;
            UserId = userId;
            QuestionText = questionText;
            QuestionDescription = questionDescription;
        }

        public Question(int? questionId, DateTime createdDate, int userId, string questionText, string questionDescription)
        {
            QuestionId = questionId;
            CreatedDate = createdDate;
            UserId = userId;
            QuestionText = questionText;
            QuestionDescription = questionDescription;
        }
    }
}
