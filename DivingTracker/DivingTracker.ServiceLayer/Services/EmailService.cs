using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using CommonCode.BusinessLayer;
using DivingTracker.ServiceLayer.Enums;
using CommonCode.BusinessLayer.Helpers;
using CommonCode.BusinessLayer.Services;
using DivingTracker.ServiceLayer.Interfaces;
using DivingTracker.ServiceLayer.Workflows;

namespace DivingTracker.ServiceLayer.Services
{
    public class EmailService : ServiceBase<IDbConnection, IDbTransaction>, IEmailService
    {
        private readonly EmailWorkflow _emailWorkflow;
        private readonly SmtpClient _smtpClient;

        public EmailService(IUnitOfWork<IDbConnection, IDbTransaction> unitOfWork, SmtpClient smtpClient,
            EmailWorkflow emailWorkflow)
            : base(unitOfWork)
        {
            Verify.NotNull(emailWorkflow, nameof(emailWorkflow));
            Verify.NotNull(smtpClient, nameof(smtpClient));

            _emailWorkflow = emailWorkflow;
            _smtpClient = smtpClient;
        }

        public DataResult Send(EmailType emailType, int[] userIds)
        {
            var emails = Enumerable.Empty<MailMessage>();

            UnitOfWork.Begin();

            switch (emailType)
            {
                case EmailType.NoTemplate:
                    break;
                case EmailType.ConfirmEmail:
                    var emailsResult = _emailWorkflow.GetConfirmationEmail(userIds);
                    if (emailsResult.Type != DataResultType.Success)
                    {
                        return emailsResult;
                    }
                    emails = emailsResult.Value;
                    break;
            }

            UnitOfWork.End();

            foreach (var email in emails)
            {
                _smtpClient.Send(email);
            }

            return new DataResult(DataResultType.Success, "Emails sent successfully.");
        }

        public DataResult Send(EmailType emailType, string subject, string body)
        {
            throw new System.NotImplementedException();
        }
    }
}
