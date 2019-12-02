using CommonCode.BusinessLayer;
using DivingTracker.ServiceLayer.Enums;

namespace DivingTracker.ServiceLayer.Interfaces
{
    public interface IEmailService
    {
        DataResult Send(EmailType emailType, int[] userIds);
    }
}