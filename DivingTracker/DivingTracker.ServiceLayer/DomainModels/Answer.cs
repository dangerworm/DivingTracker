using System;
using CommonCode.BusinessLayer.Interfaces;
using DivingTracker.ServiceLayer.Enums;

namespace DivingTracker.ServiceLayer.DomainModels
{
    public class Answer : IIdentifiableByInteger
    {
        public int? Id => AnswerId;
        public int? AnswerId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
        public string AnswerText { get; set; }
        public string AnswerDescription { get; set; }
        public ConceptResourceType ConceptResourceTypeId { get; set; }
        public string ResourceTypeDescription { get; set; }
        public string ResourceIdentifier { get; set; }

        public Answer()
        {
        }

        public Answer(DateTime createdDate, int userId, string answerText, string answerDescription,
            ConceptResourceType conceptResourceTypeId, string resourceTypeDescription, string resourceIdentifier)
        {
            CreatedDate = createdDate;
            UserId = userId;
            AnswerText = answerText;
            AnswerDescription = answerDescription;
            ConceptResourceTypeId = conceptResourceTypeId;
            ResourceTypeDescription = resourceTypeDescription;
            ResourceIdentifier = resourceIdentifier;
        }

        public Answer(int? answerId, DateTime createdDate, int userId, string answerText,
            string answerDescription, ConceptResourceType conceptResourceTypeId, string resourceTypeDescription,
            string resourceIdentifier)
            : this(createdDate, userId, answerText, answerDescription, conceptResourceTypeId,
                resourceTypeDescription, resourceIdentifier)
        {
            AnswerId = answerId;
        }
    }
}
