using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonCode.BusinessLayer.Helpers;
using DivingTracker.ServiceLayer.Enums;

namespace DivingTracker.ServiceLayer.Entities
{
    public class AnswerDto
    {
        private string _answerText;
        private string _answerDescription;

        public int? AnswerId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }

        [AllowHtml]
        public string AnswerText
        {
            get { return string.IsNullOrWhiteSpace(_answerText) ? " " : _answerText.Unescape(); }
            set { _answerText = value.Escape(); }
        }

        [AllowHtml]
        public string AnswerDescription
        {
            get { return _answerDescription.Unescape(); }
            set { _answerDescription = value.Escape(); }
        }

        public int QuestionId { get; set; }
        public ConceptResourceType ConceptResourceTypeId { get; set; }
        public string ResourceTypeDescription { get; set; }
        public string ResourceIdentifier { get; set; }
        public IEnumerable<QuestionDto> Questions { get; set; }

        public bool IsSelected { get; set; }

        public AnswerDto()
        {
        }

        public AnswerDto(int userId, int questionId)
        {
            UserId = userId;
            QuestionId = questionId;
        }
    }
}
