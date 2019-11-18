using CommonCode.BusinessLayer;
using DivingTracker.ServiceLayer.Entities;

namespace DivingTracker.ServiceLayer.Validators
{
    public class QuestionValidator : BaseValidator<QuestionDto>
    {
        public override DataResult<QuestionDto> Validate(QuestionDto value)
        {
            var result = new DataResult<QuestionDto>(value, DataResultType.ValidationError, FriendlyMessage);

            if (string.IsNullOrWhiteSpace(value.QuestionText))
            {
                result.Validation.Add(nameof(value.QuestionText), "The question must contain some text.");
            }
            else if (value.QuestionText.Length > 512)
            {
                result.Validation.Add(nameof(value.QuestionText), "The question is too long. Please use up to 512 characters.");
            }

            if (value.QuestionDescription?.Length > 1024)
            {
                result.Validation.Add(nameof(value.QuestionDescription), "The question description is too long. Please use up to 1024 characters.");
            }

            return !result.Validation.HasAny 
                ? new DataResult<QuestionDto>(value, DataResultType.Success, "The question is valid.")
                : result;
        }
    }
}
