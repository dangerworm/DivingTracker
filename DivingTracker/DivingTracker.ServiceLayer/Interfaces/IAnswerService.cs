using System.Collections.Generic;
using CommonCode.BusinessLayer;
using DivingTracker.ServiceLayer.Entities;

namespace DivingTracker.ServiceLayer.Interfaces
{
    public interface IAnswerService
    {
        DataResult<AnswerDto> Create(AnswerDto value);
        DataResult<AnswerDto> Read(int id);
        DataResult<IEnumerable<AnswerDto>> ReadAllByUserId(int userId);
        DataResult Delete(int id);

        DataResult SubmitAnswer(int userId, int questionId, int answerId);
    }
}
