using CommonCode.BusinessLayer;
using DivingTracker.ServiceLayer.Interfaces;

namespace DivingTracker.ServiceLayer.Validators
{
    public abstract class BaseValidator<T> : IValidator<T>
    {
        protected virtual string FriendlyMessage { get; }
        protected virtual string InternalMessage { get; }

        protected BaseValidator()
        {
            FriendlyMessage = "Please correct the validation errors and try again.";
            InternalMessage = "The ValidationCollection is not empty. The items must be corrected before continuing.";
        }

        public abstract DataResult<T> Validate(T value);
    }
}
