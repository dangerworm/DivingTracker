using System;
using System.Collections.Generic;
using CommonCode.BusinessLayer;
using DivingTracker.ServiceLayer.Entities;

namespace DivingTracker.ServiceLayer.Interfaces
{
    public interface IQuestionService
    {
        DataResult<QuestionDto> Create(QuestionDto value);

        DataResult<QuestionDto> Read(int questionId, int userId);

        DataResult<IEnumerable<QuestionDto>> ReadAllByResponseTime(int userId,
            int? numberOfResults = null, DateTime? startDate = null, DateTime? endDate = null);

        DataResult<IEnumerable<QuestionDto>> ReadAllByPopularity(int userId, 
            int? numberOfResults = null, DateTime? startDate = null, DateTime? endDate = null);

        DataResult<IEnumerable<QuestionDto>> ReadAllByUserId(int userId);

        DataResult<QuestionDto> Update(QuestionDto value);

        DataResult Delete(int id);

        DataResult<QuestionAnalyticsDto> GetAnalytics(int questionId);

        DataResult<IEnumerable<QuestionDto>> Search(string term);
    }
}
