using CommonCode.BusinessLayer;
using DivingTracker.ServiceLayer.Entities;

namespace DivingTracker.ServiceLayer.Validators
{
    public class AnswerValidator : BaseValidator<AnswerDto>
    {
        public override DataResult<AnswerDto> Validate(AnswerDto value)
        {
            var result = new DataResult<AnswerDto>(value, DataResultType.ValidationError, FriendlyMessage);

            if (string.IsNullOrWhiteSpace(value.AnswerText))
            {
                result.Validation.Add(nameof(value.AnswerText), "The answer must contain some text.");
            }
            else if (value.AnswerText.Length > 256)
            {
                result.Validation.Add(nameof(value.AnswerText), "The answer is too long. Please use up to 256 characters.");
            }

            if (value.AnswerDescription?.Length > 1024)
            {
                result.Validation.Add(nameof(value.AnswerDescription), "The answer description is too long. Please use up to 1024 characters.");
            }

            return !result.Validation.HasAny 
                ? new DataResult<AnswerDto>(value, DataResultType.Success, "The answer is valid.")
                : result;
        }
    }
}
