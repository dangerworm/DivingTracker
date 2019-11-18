using CommonCode.BusinessLayer;

namespace DivingTracker.ServiceLayer.Interfaces
{
    public interface IValidator<T>
    {
        DataResult<T> Validate(T value);
    }
}
