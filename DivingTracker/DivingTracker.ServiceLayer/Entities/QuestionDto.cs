using System;
using System.Collections.Generic;
using CommonCode.BusinessLayer.Helpers;
using DivingTracker.ServiceLayer.Helpers;

namespace DivingTracker.ServiceLayer.Entities
{
    public class QuestionDto 
    {
        private string _questionText;
        private string _questionDescription;

        public int? QuestionId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
        public int? SelectedAnswerId { get; set; }
        public UserDto User { get; set; }
        public QuestionAnalyticsDto Analytics { get; set; }
        public IEnumerable<AnswerDto> Answers { get; set; }
        public IEnumerable<QuestionEditDto> History { get; set; }

        public string QuestionText
        {
            get { return string.IsNullOrWhiteSpace(_questionText) ? " " : _questionText.Unescape(); }
            set { _questionText = value.Escape(); }
        }

        public string QuestionDescription
        {
            get { return _questionDescription.Unescape(); }
            set { _questionDescription = value.Escape(); }
        }

        public QuestionDto()
        {
        }

        public QuestionDto(int userId, string questionText)
        {
            UserId = userId;
            QuestionText = questionText;
        }
    }
}
